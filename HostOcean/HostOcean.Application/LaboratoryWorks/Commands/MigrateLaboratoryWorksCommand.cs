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

                        var laboratoryWorks =
                            (await _groupSheduleService.GetLaboratoryWorksForPeriod(group.CalendarId, startDate,
                                endDate))
                            .Select(x =>
                            {
                                x.Group = group;
                                return x;
                            });



                        var splitedLaboratoryWorks =
                            await laboratoryWorks.SplitByPredicateAsync(NewLaboratoryWorkPredicate);

                        var newLaboratoryWorks = splitedLaboratoryWorks.Match;
                        foreach (var labwork in newLaboratoryWorks)
                        {
                            var queue = new Queue() { LaboratoryWork = labwork };
                            labwork.Queue = queue;

                            _unitOfWork.Queues.Add(queue);
                        }

                        _unitOfWork.LaboratoryWorks.AddRange(newLaboratoryWorks);
                        _unitOfWork.LaboratoryWorks.UpdateRange(splitedLaboratoryWorks.NoMatch);
                        await _unitOfWork.SaveAsync();

                    }
                    //TODO: Reolve bug with 404 NOT FOUND Calendar page
                    catch (GoogleApiException googleApiException) when (googleApiException.HttpStatusCode ==
                                                                        HttpStatusCode.NotFound)
                    {
                        //Ignored
                    }
                    // TODO: Add logger to log any exceptions
                    catch (Exception)
                    {
                        //Ignored
                    }
                }
                return await Unit.Task;
            }

            private async Task<bool> NewLaboratoryWorkPredicate(LaboratoryWork laboratoryWork) => 
                !(await _unitOfWork.LaboratoryWorks.IsExistByIdAsync(laboratoryWork.Id));
            
        }
    }
}