using System;
using HostOcean.Api.Infrastructure.BsuirGroupService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HostOcean.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        private readonly IHostingEnvironment _hostingEnvironment;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            if (_hostingEnvironment.IsDevelopment())
            {
                services.AddSwaggerGen(swagGen =>
                {
                    swagGen.SwaggerDoc(
                        Configuration["Swagger:Info:Version"], 
                        new Info
                        {
                            Title = Configuration["Swagger:Info:Title"],
                            Version = Configuration["Swagger:Info:Version"]
                        });
                });
            }

            services.AddHttpClient<IISHttpClient>(configureClient =>
            {
                configureClient.BaseAddress = new Uri("https://journal.bsuir.by");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

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