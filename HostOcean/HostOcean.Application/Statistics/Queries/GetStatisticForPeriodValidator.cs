using FluentValidation;

namespace HostOcean.Application.Statistics.Queries
{
    class GetStatisticForPeriodValidator : AbstractValidator<GetStatisticForPeriodQuery>
    {
        public GetStatisticForPeriodValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.EndPeriod).GreaterThan(x => x.StartPeriod);
        }
    }
}
