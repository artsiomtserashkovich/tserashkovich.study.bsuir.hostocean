using System.Collections.Generic;
using Hangfire;
using Hangfire.Dashboard;
using HostOcean.Api.Filters;
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
                .RegisterHangfire(Configuration)
                .RegisterMvc()
                .RegisterAutoMapper()
                .ConfigureDataBase(Configuration)
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
            app.UseHangfireServer();
            app.UseHangfireDashboard(Configuration["HangfireSettings:HangfirePath"],new DashboardOptions()
            {
                Authorization = new List<IDashboardAuthorizationFilter>
                {
                    new HangfireNoAuthFilter(),
                }
            });

            app.InitializeDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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