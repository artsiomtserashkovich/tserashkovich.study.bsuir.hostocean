using FluentValidation;

namespace HostOcean.Application.Users.Commands.CreateUser
{
    public class UpdateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username must be non empty");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Wrong email adderess");
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group must be non empty");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must have 6+ symbols");
        }
    }
}