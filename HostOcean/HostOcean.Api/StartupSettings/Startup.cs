using System;
using HostOcean.Api.StartupSettings.StartupExtensions;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure.BsuirGroupService;
using HostOcean.Infrastructure.GroupScheduleService;
using HostOcean.Persistence;
using HostOcean.Persistence.Interfaces;
using HostOcean.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HostOcean.Api.StartupSettings
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connection = Configuration.GetConnectionString("MSSQLDatabaseConnectionString");
            services.AddDbContext<HostOceanDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("HostOcean.Persistence")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<HostOceanDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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
                configureClient.BaseAddress = new Uri(Configuration["IISBsuirClient:UriBaseAddress"]);
            });
            
            services.AddGoogleCalendarClient<IGoogleCalendarClient,GoogleCalendarV3Client,GoogleCalendarApiConfiguration>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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