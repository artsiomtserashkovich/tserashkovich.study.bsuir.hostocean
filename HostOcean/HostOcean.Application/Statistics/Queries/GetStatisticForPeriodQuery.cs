using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Statistics.Models;
using HostOcean.Domain.Entities;
using MediatR;

namespace HostOcean.Application.Statistics.Queries
{
    public class GetStatisticForPeriodQuery: IRequest<StatisticModel>
    {
        public string UserId { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        public class GetStatisticForPeriodQueryHandler: IRequestHandler<GetStatisticForPeriodQuery, StatisticModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetStatisticForPeriodQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<StatisticModel> Handle(GetStatisticForPeriodQuery request, CancellationToken cancellationToken)
            {
                if (await _unitOfWork.UserManager.FindByIdAsync(request.UserId) == null)
                    throw new NotFoundException(nameof(User),request.UserId);

                var predicate = GetPredicateForStatistic(request.UserId, request.StartPeriod, request.EndPeriod);
                
                var userQueuesInformation = _unitOfWork.UserQueues.GetPredicatedAsync(
                    predicate, 
                    queue => new { queue.Id, queue.QueueId, queue.CreatedOn })
                        .ToList();

                var queueStatistics = new List<QueueStatisticModel>();
                foreach (var userQueueInformation in userQueuesInformation)
                {
                    var queueStatistic =
                        await GetQueueStatisticAsync(userQueueInformation.Id, userQueueInformation.QueueId);
                    queueStatistics.Add(queueStatistic);
                };

                var queueGlobalStatisticStatistic = GetQueueGlobalStatistic(queueStatistics);

                return new StatisticModel
                {
                    AverageTakeQueueTime = queueGlobalStatisticStatistic.AverageTakeQueueTime,
                    AveragePlace = queueGlobalStatisticStatistic.AveragePlace,
                    CountQueues = userQueuesInformation.Count(),
                    QueueStatistics = queueStatistics,
                };
            }

            private (TimeSpan AverageTakeQueueTime, int AveragePlace) GetQueueGlobalStatistic(
                ICollection<QueueStatisticModel> queueStatistics)
            {
                if (queueStatistics.Count != 0)
                {
                    return (TimeSpan.FromMinutes(queueStatistics.Average(x => x.TakeQueueTime.TotalMinutes)),
                                (int)queueStatistics.Average(x => x.Place));
                }

                return (TimeSpan.Zero, 0);
            }

            private async Task<QueueStatisticModel> GetQueueStatisticAsync(string userQueueId, string queueId)
            {
                var queue = await _unitOfWork.Queues.GetQueueWithUserQueues(queueId);
                var userQueues = queue.UserQueues.OrderBy(x => x.CreatedOn)
                    .Select((item, index) => new {item,index}).ToArray();

                var userQueue = userQueues.FirstOrDefault(x => x.item.Id == userQueueId) 
                                    ?? throw new NotFoundException(nameof(UserQueue), userQueueId);

                var createdQueueDateTime = (queue.CreatedOn ?? DateTime.Today);

                return new QueueStatisticModel
                {
                    ParticipantsCount = userQueues.Count(),
                    Place = userQueue.index + 1,
                    QueueId = queueId,
                    QueueTitle = queue.LaboratoryWorkEvent.LaboratoryWork.Title,
                    QueueStartTime = createdQueueDateTime,
                    TakeQueueTime = userQueue.item.CreatedOn - createdQueueDateTime, 
                };
            }

            private static Expression<Func<UserQueue, bool>> GetPredicateForStatistic(
                string userId, DateTime starTime, DateTime endTime)
            {
                return userQueue => userQueue.UserId == userId 
                                    && userQueue.CreatedOn >= starTime 
                                    && userQueue.CreatedOn <= endTime;
            }
        }
    }
}
