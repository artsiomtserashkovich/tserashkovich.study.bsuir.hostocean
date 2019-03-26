using System.Reflection;
using AutoMapper;
using HostOcean.Application.Infrastructure.MapperProfiles;
using HostOcean.Infrastructure.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupAutoMapperExtension
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(InfrastructureProfile)), Assembly.GetAssembly(typeof(LaboratoryWorkProfile)));

            return services;
        }
    }
}
