using FluentValidation;

namespace HostOcean.Application.Statistics.Queries
{
    class GetCurrentUserStatisticQueryValidator : AbstractValidator<GetCurrentUserStatisticQuery>
    {
        public GetCurrentUserStatisticQueryValidator()
        {
            RuleFor(x => x.EndPeriod).GreaterThan(x => x.StartPeriod);
        }
    }
}
