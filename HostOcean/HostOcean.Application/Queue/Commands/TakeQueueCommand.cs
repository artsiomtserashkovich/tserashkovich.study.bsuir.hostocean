using HostOcean.Domain.Entities;
using HostOcean.Persistence.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
                var entity = new Domain.Entities.UserQueue
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
