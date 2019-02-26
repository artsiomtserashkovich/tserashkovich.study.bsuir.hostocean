using System;
using HostOcean.Infrastructure.BsuirGroupService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupHttpClientsExtension
    {
        public static IServiceCollection RegisterHttpClients(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<IISHttpClient>(configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["IISBsuirClient:UriBaseAddress"]);
            });

            return services;
        }
    }
}
