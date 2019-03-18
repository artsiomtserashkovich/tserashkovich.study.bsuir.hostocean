using HostOcean.Application.Interfaces.Persistence;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Queues.Commands
{
    public class LeaveQueueCommand : IRequest
    {
        public string UserId { get; set; }
        public string QueueId { get; set; }

        public class LeaveQueueCommandHandler : IRequestHandler<LeaveQueueCommand>
        {
            private readonly IUnitOfWork _unitOfWork;

            public LeaveQueueCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(LeaveQueueCommand request, CancellationToken cancellationToken)
            {
                var entity = _unitOfWork.UserQueues.Find(e => e.UserId == request.UserId && e.QueueId == request.QueueId).FirstOrDefault();
                if (entity == null)
                {
                    throw new ValidationException("User not in queue");
                }


                _unitOfWork.UserQueues.Remove(entity);
                await _unitOfWork.SaveAsync();

                return Unit.Value;
            }
        }
    }
}
