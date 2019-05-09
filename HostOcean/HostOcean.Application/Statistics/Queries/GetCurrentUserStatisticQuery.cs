using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Statistics.Models;
using HostOcean.Application.Users.Queries;
using HostOcean.Domain.Entities;
using MediatR;

namespace HostOcean.Application.Statistics.Queries
{
    public class GetCurrentUserStatisticQuery: IRequest<StatisticModel>
    {
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        public class GetCurrentUserStatisticQueryHandler: IRequestHandler<GetCurrentUserStatisticQuery, StatisticModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;

            public GetCurrentUserStatisticQueryHandler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }

            public async Task<StatisticModel> Handle(GetCurrentUserStatisticQuery request, CancellationToken cancellationToken)
            {
                var user = await _mediator.Send(new GetCurrentUserQuery(), cancellationToken);
                
                var predicate = GetPredicateForStatistic(user.Id, request.StartPeriod, request.EndPeriod);
                
                var userQueuesInformation = _unitOfWork.UserQueues.GetPredicatedAsync(
                    predicate, 
                    userQueue => new { userQueue.Id, userQueue.QueueId, userQueue.CreatedOn })
                        .ToList();

                var queueStatistics = new List<QueueStatisticModel>();

                foreach (var userQueueInformation in userQueuesInformation)
                {
                    var queueStatistic = await GetQueueStatisticAsync(userQueueInformation.Id,
                        userQueueInformation.QueueId);
                    queueStatistics.Add(queueStatistic);
                };

                var (averageTakeQueueTime, averagePlace) = GetAggregateQueuesStatistic(queueStatistics);

                return new StatisticModel
                {
                    AverageTakeQueueTime = averageTakeQueueTime,
                    AveragePlace = averagePlace,
                    CountQueues = userQueuesInformation.Count(),
                    QueueStatistics = queueStatistics,
                };
            }

            private (TimeSpan AverageTakeQueueTime, int AveragePlace) GetAggregateQueuesStatistic(
                ICollection<QueueStatisticModel> queueStatistics)
            {
                if (queueStatistics.Count == 0)
                    return (TimeSpan.Zero, 0);
                
                int averagePlace = (int)queueStatistics.Average(x => x.Place);
                TimeSpan averageTakeQueueTime = TimeSpan.FromMinutes(queueStatistics.Average(x => x.TakeQueueTime.TotalMinutes));
                return (averageTakeQueueTime, averagePlace);
            }

            private async Task<QueueStatisticModel> GetQueueStatisticAsync(string userQueueId, string queueId)
            {
                var queue = await _unitOfWork.Queues.GetQueueWithUserQueues(queueId);

                var userQueues = queue.UserQueues
                                        .OrderBy(x => x.CreatedOn)
                                        .Select((item, index) => new { item,index } )
                                        .ToArray();

                var userQueue = userQueues.SingleOrDefault(x => x.item.Id == userQueueId) 
                                    ?? throw new NotFoundException(nameof(UserQueue), userQueueId);

                var createdQueueDateTime = queue.CreatedOn ?? DateTime.Today;

                return new QueueStatisticModel
                {
                    ParticipantsCount = userQueues.Count(),
                    Place = userQueue.index + 1,
                    QueueId = queueId,
                    QueueTitle = queue.LaboratoryWorkEvent.LaboratoryWork.Title,
                    QueueStartTime = createdQueueDateTime,
                    TakeQueueTime = (userQueue.item.CreatedOn - createdQueueDateTime), 
                };
            }

            private static Expression<Func<UserQueue, bool>> GetPredicateForStatistic(
                string userId, DateTime starTime, DateTime endTime)
            {
                return userQueue => userQueue.UserId == userId 
                                        && userQueue.CreatedOn.Date >= starTime.Date 
                                        && userQueue.CreatedOn.Date <= endTime.Date;
            }
        }
    }
}
