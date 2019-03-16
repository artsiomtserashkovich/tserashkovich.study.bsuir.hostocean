using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Persistence;
using HostOcean.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDataBaseContextInitializerExtension
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddTransient<IHostOceanDataBaseContextInitializer, HostOceanDataBaseContextInitializer>();
            var connection = Configuration.GetConnectionString("MSSQLDatabaseConnectionString");
            services.AddDbContext<HostOceanDataBaseContext>(options => {                
                options.UseLazyLoadingProxies();
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HostOceanDB;Integrated Security=True;", b => b.MigrationsAssembly("HostOcean.Persistence"));
            });

            return services;
        }
    }
}
