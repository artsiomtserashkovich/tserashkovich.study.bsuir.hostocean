using HostOcean.Persistence.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            HostOceanDbInitializer.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
        }
    }
}
