using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Google;
using HostOcean.Application.Extension;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using MediatR;

namespace HostOcean.Application.LaboratoryWorks.Commands
{
    public class MigrateLaboratoryWorksCommand: IRequest
    {
        public TimeSpan MigratePeriod { get; set; }

        public class MigrateLaboratoryWorksCommandHandler : IRequestHandler<MigrateLaboratoryWorksCommand>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IGroupSheduleService _groupSheduleService;

            public MigrateLaboratoryWorksCommandHandler(IUnitOfWork unitOfWork,
                IGroupSheduleService groupSheduleService)
            {
                _unitOfWork = unitOfWork;
                _groupSheduleService = groupSheduleService;
            }
            public async Task<Unit> Handle(MigrateLaboratoryWorksCommand request, CancellationToken cancellationToken)
            {
                var groups = _unitOfWork.Groups.All;
                var startDate = DateTime.Now;
                var endDate = startDate + request.MigratePeriod;

                foreach (var group in groups ?? Enumerable.Empty<Group>())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(group.CalendarId))
                            continue;

                        var events = await _groupSheduleService.GetEventsForPeriod(group.CalendarId, startDate, endDate);

                        var splitedEvents = await events.SplitByPredicateAsync(NewLaboratoryWorkEventPredicate);

                        var newEvents = splitedEvents.Match;
                        foreach (var labworkEvent in newEvents)
                        {
                            var labwork = labworkEvent.LaboratoryWork;
                            labwork.Group = group;

                            var entity = _unitOfWork.LaboratoryWorks.SingleOrDefault(e => e.Lecturer == labwork.Lecturer && e.Title == labwork.Title && e.Group.Id == labwork.Group.Id);
                            if (entity == null)
                            {
                                _unitOfWork.LaboratoryWorks.Add(labwork);
                            } else
                            {
                                labwork = entity;
                            }
                            
                            var queue = new Queue() { LaboratoryWorkEvent = labworkEvent };
                            labworkEvent.Queue = queue;
                            labworkEvent.LaboratoryWork = labwork;
                            _unitOfWork.Queues.Add(queue);
                            _unitOfWork.Events.Add(labworkEvent);

                            await _unitOfWork.SaveAsync();
                        }

                       // _unitOfWork.Events.UpdateRange(splitedEvents.NoMatch);
                        await _unitOfWork.SaveAsync();

                    }
                    //TODO: Reolve bug with 404 NOT FOUND Calendar page
                    catch (GoogleApiException googleApiException) when (googleApiException.HttpStatusCode == HttpStatusCode.NotFound)
                    {
                        //Ignored
                    }
                    // TODO: Add logger to log any exceptions
                    catch (Exception ex)
                    {
                        //Ignored
                    }
                }
                return await Unit.Task;
            }

            private async Task<bool> NewLaboratoryWorkEventPredicate(LaboratoryWorkEvent labworkEvent) => 
                !(await _unitOfWork.Events.IsExistByIdAsync(labworkEvent.Id));
            
        }
    }
}