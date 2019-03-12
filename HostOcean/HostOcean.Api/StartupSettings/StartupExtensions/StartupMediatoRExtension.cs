using System.Reflection;
using HostOcean.Application.Infrastructure.RequestPipelineHandlers;
using HostOcean.Application.Ping.Query.Ping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupMediatoRExtension
    {
        public static IServiceCollection RegisterMediatoR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetAssembly(typeof(PingQuery)));
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationRequestPipelineHandler<,>));

            return services;
        }
    }
}
