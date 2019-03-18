using FluentValidation;

namespace HostOcean.Application.Queues.Commands
{
    public class LeaveQueueValidator : AbstractValidator<LeaveQueueCommand>
    {
        public LeaveQueueValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.QueueId).NotEmpty();
        }
    }
}
