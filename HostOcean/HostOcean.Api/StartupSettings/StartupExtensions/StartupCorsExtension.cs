using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupCorsExtension
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000");
            }));

            return services;
        }
    }
}
