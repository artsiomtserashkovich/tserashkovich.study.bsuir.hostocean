using HostOcean.Domain.Entities;
using HostOcean.Infrastructure;
using HostOcean.Persistence.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Queue.Commands
{
    public class TakeQueueCommand : IRequest<ServiceResult>
    {
        public string UserId { get; set; }
        public string QueueId { get; set; }
        public short Order { get; set; }

        public class Handler : IRequestHandler<TakeQueueCommand, ServiceResult>
        {
            private readonly IMediator _mediator;
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IMediator mediator, IUnitOfWork unitOfWork)
            {
                _mediator = mediator;
                _unitOfWork = unitOfWork;
            }

            public async Task<ServiceResult> Handle(TakeQueueCommand request, CancellationToken cancellationToken)
            {
                var entity = new UserQueue
                {
                    UserId = request.UserId,
                    QueueId = request.QueueId,
                    Order = request.Order
                };

                try
                {
                    _unitOfWork.UserQueues.Add(entity);
                    await _unitOfWork.SaveAsync();

                    return new ServiceResult();
                }
                catch (Exception ex)
                {
                    return new ServiceResult(ex);
                }
            }
        }
    }
}
