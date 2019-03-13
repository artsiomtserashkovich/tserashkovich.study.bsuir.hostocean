﻿using HostOcean.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistance;

namespace HostOcean.Application.Queue.Commands
{
    public class TakeQueueCommand : IRequest
    {
        public string UserId { get; set; }
        public string QueueId { get; set; }
        public short Order { get; set; }

        public class TakeQueueCommandHandler : IRequestHandler<TakeQueueCommand>
        {
            private readonly IUnitOfWork _unitOfWork;

            public TakeQueueCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(TakeQueueCommand request, CancellationToken cancellationToken)
            {
                var entity = new UserQueue
                {
                    UserId = request.UserId,
                    QueueId = request.QueueId,
                    Order = request.Order
                };
            
                _unitOfWork.UserQueues.Add(entity);
                await _unitOfWork.SaveAsync();

                return Unit.Value;
            }
        }
    }
}