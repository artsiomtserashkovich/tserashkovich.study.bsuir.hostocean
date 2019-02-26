using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupIdentityExtension
    {
        public static IServiceCollection ConfigureIdentity<TUser, TRole, TContext>(this IServiceCollection services) where TUser : class where TRole : class where TContext : DbContext
        {
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
