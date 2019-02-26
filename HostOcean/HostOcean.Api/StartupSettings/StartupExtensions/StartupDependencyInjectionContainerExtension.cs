using HostOcean.Persistence.Interfaces;
using HostOcean.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDependencyInjectionContainerExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}