using FluentValidation;

namespace HostOcean.Application.Ping.Query.PingGreeting
{
    public class PingGreetingQueryValidator : AbstractValidator<PingGreetingQuery>
    {
        public PingGreetingQueryValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1,20);
        }
    }
}
