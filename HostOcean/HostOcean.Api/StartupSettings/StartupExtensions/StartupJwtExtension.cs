﻿using System.Text;
using HostOcean.Application.Infrastructure.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HostOcean.Api.StartupSettings.StartupExtensions
{
    public static class StartupJwtExtension
    {
        public static IServiceCollection RegisterJwtAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            //TODO: fix ioptions
            var jwtSettings = new JwtSettings()
            {
                Audience = configuration["JwtSettings:Audience"],
                Issuer = configuration["JwtSettings:Issuer"],
                Key = configuration["JwtSettings:Key"],
                Lifetime = int.Parse(configuration["JwtSettings:Lifetime"])
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });

            return services;
        }
    }
}