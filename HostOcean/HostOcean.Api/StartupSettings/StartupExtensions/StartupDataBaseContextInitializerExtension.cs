using HostOcean.Persistence.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDataBaseContextInitializerExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            HostOceanDbInitializer.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
        }
    }
}
