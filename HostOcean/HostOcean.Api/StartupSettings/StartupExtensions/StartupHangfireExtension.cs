using System;
using Hangfire;
using HostOcean.Application.ApplicationSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupHangfireExtension
    {
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<HangfireSettings>(conf => Configuration.Get<HangfireSettings>());
            services.AddHangfire(configuration =>
                {
                    configuration.UseSqlServerStorage(
                        Configuration.GetConnectionString("HangfireDatabaseConnectionString"));
                }
            );
            return services;
        }

    }
}