using HostOcean.Api.StartupSettings.StartupExtensions;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.GroupScheduleService;
using HostOcean.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        private IHostingEnvironment HostingEnvironment { get; }
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) =>
            services
                .RegisterMvc()
                .RegisterAutoMapper()
                .AddOptions()
                .ConfigureDataBase(Configuration)
                .ConfigureCors()
                .ConfigureIdentity<User, IdentityRole, HostOceanDbContext>()
                .RegisterDependencies()
                .RegisterSwaggerGen(HostingEnvironment,Configuration)
                .RegisterMediatoR()
                .RegisterJwtAuthentication(Configuration)
                .RegisterHttpClients(Configuration)
                .AddGoogleCalendarClient<IGoogleCalendarClient, GoogleCalendarV3Client, GoogleCalendarApiConfiguration>
                    (Configuration);
        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.InitializeDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsPolicy");
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(swaggerConfiguration =>
                {
                    swaggerConfiguration.SwaggerEndpoint(
                        Configuration["Swagger:SwaggerPath"],
                        Configuration["Swagger:ApplicationName"]
                    );
                });
            }
        }
    }
}