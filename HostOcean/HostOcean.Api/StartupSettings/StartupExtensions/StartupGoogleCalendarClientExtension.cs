using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupGoogleCalendarClientExtension
    {
        public static IServiceCollection AddGoogleCalendarClient<TInterface, TImplementation, TConfiguration>
            (this IServiceCollection services, IConfiguration Configuration) 
            where TImplementation : class, TInterface where TInterface : class where TConfiguration : class
        {
            services.Configure<TConfiguration>(
                Configuration.GetSection(typeof(TConfiguration).Name));

            services.AddTransient<TInterface, TImplementation>();

            return services;
        } 
    }
}
