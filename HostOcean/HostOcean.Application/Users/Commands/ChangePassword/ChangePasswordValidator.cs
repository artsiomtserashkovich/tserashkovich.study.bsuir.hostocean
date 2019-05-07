using FluentValidation;

namespace HostOcean.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty();
            RuleFor(x => x.NewPasswordConfirmation).NotEmpty().Equal(c => c.NewPassword).WithMessage("Password doesn't match");
        }
    }
}