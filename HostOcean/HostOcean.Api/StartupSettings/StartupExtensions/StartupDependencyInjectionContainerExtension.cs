using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Infrastructure.GroupScheduleService;
using HostOcean.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupDependencyInjectionContainerExtension
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGroupSheduleService, GroupSheduleService>();
            services.AddScoped<IBsuirGroupService, BsuirGroupService>();
            services.AddScoped<IUserQueueRepository, UserQueueRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserQueueRepository, UserQueueRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}