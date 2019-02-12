using System;
using HostOcean.Api.Infrastructure.BsuirGroupService;
using HostOcean.Api.Infrastructure.GroupScheduleService;
using HostOcean.Api.StartupSettings.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpClient<IISHttpClient>(configureClient =>
            {
                configureClient.BaseAddress = new Uri("https://journal.bsuir.by");
            });
            
            services.AddGoogleCalendarClient<IGoogleCalendarClient,GoogleCalendarV3Client,GoogleCalendarApiConfiguration>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}