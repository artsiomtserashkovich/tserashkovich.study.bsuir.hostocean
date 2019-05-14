using FluentValidation;

namespace HostOcean.Application.Requests.Commands.CreateSwapRequest
{
    public class CreateSwapRequestValidator : AbstractValidator<CreateSwapRequestCommand>
    {
        public CreateSwapRequestValidator()
        {
            RuleFor(x => x.QueueId).NotEmpty();
            RuleFor(x => x.ReceiverUserId).NotEmpty();
        }
    }
}
