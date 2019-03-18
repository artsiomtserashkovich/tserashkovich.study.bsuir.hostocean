using Hangfire;
using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Infrastructure.Hangfire;
using HostOcean.Infrastructure.Hangfire.CommandExecutor;
using HostOcean.Infrastructure.Hangfire.SheduleCommandInitializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupHangfireExtension
    {
        public static void InitializeHangfireSheduleCommands(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;
            serviceProvider.GetService<ISheduleCommandsInitializer>().InitializeSheduleCommands();
        }
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStartupCommandSheduler, CommandsScheduler>();
            services.AddTransient<ISheduleCommandsInitializer, SheduleCommandsInitializer>();
            services.AddTransient<ICommandsSheduler, CommandsScheduler>();
            services.AddTransient<ICommandExecutor, MediatRCommandExecutor>();
            services.Configure<HangfireSettings>(configuration.GetSection(nameof(HangfireSettings)));
            services.AddHangfire(conf =>
                {
                    conf.UseSqlServerStorage(
                        configuration.GetConnectionString("HangfireDatabaseConnectionString"));
                }
            );
            return services;
        }

    }
}