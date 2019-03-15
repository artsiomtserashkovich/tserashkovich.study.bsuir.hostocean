using HostOcean.Persistence;
using HostOcean.Persistence.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDataBaseContextInitializerExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            HostOceanDbInitializer.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
        }

        public static IServiceCollection ConfigureDataBase(this IServiceCollection services,IConfiguration Configuration)
        {
            var connection = Configuration.GetConnectionString("MSSQLDatabaseConnectionString");
            services.AddDbContext<HostOceanDbContext>(options => {                
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connection, b => b.MigrationsAssembly("HostOcean.Persistence"));
            });

            return services;
        }
    }
}
