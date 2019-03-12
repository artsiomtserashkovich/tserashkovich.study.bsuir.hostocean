using FluentValidation.AspNetCore;
using HostOcean.Api.Filters;
using HostOcean.Application.Ping.Query.PingGreeting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupMVCExtension
    {
        public static IServiceCollection RegisterMvc(this IServiceCollection services)
        {
            services.AddMvc(options =>
                {
                    options.Filters.Add<MvcExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PingGreetingQueryValidator>());

            return services;
        }
    }
}