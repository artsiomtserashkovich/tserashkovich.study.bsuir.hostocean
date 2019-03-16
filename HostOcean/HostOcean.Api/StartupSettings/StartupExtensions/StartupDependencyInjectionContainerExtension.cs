using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDependencyInjectionContainerExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBsuirGroupService, BsuirGroupService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}