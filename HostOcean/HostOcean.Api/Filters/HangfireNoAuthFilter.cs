using Hangfire.Dashboard;

namespace HostOcean.Api.Filters
{
    public class HangfireNoAuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}