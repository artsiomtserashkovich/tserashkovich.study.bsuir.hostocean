using HostOcean.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Queues.Commands
{
    public class TakeQueueCommand : IRequest
    {
        public string UserId { get; set; }
        public string QueueId { get; set; }

        public class TakeQueueCommandHandler : IRequestHandler<TakeQueueCommand>
        {
            private readonly IUnitOfWork _unitOfWork;

            public TakeQueueCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(TakeQueueCommand request, CancellationToken cancellationToken)
            {
                var userQueue = _unitOfWork.UserQueues.Find(e => e.UserId == request.UserId && e.QueueId == request.QueueId).FirstOrDefault();
                if (userQueue != null)
                {
                    throw new FluentValidation.ValidationException("User already in queue");
                }

                var queue = _unitOfWork.Queues.Find(e => e.Id == request.QueueId).FirstOrDefault();
                if (queue.LaboratoryWorkEvent.RegistrationStartedAt > DateTime.Now)
                {
                    throw new Exception("Registration not started yet");
                }

                var entity = new Domain.Entities.UserQueue
                {
                    UserId = request.UserId,
                    QueueId = request.QueueId,
                    CreatedOn = DateTime.Now
                };

                _unitOfWork.UserQueues.Add(entity);
                await _unitOfWork.SaveAsync();

                return await Unit.Task;
            }
        }
    }
}
