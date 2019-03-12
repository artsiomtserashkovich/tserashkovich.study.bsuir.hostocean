using FluentValidation;

namespace HostOcean.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.GroupId).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}