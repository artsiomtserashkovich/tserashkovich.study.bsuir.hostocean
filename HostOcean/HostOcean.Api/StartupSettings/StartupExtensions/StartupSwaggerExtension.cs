using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupSwaggerExtension
    {
        public static IServiceCollection RegisterSwaggerGen(this IServiceCollection services, IHostingEnvironment HostingEnvironment, IConfiguration Configuration)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                services.AddSwaggerGen(swagGen =>
                {
                    swagGen.SwaggerDoc(
                        Configuration["Swagger:Info:Version"],
                        Configuration.Get<Info>());
                });
            }

            return services;
        }
    }
}
