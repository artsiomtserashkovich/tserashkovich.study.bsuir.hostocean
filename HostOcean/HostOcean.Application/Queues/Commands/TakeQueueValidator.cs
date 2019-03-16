using FluentValidation;

namespace HostOcean.Application.Queues.Commands
{
    public class TakeQueueValidator : AbstractValidator<TakeQueueCommand>
    {
        public TakeQueueValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.QueueId).NotEmpty();
            RuleFor(x => x.Order).InclusiveBetween((short)1, (short)60);
        }
    }
}
