using HostOcean.Application.Tokens.Models;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Tokens.Queries
{
    public class GenerateJwtTokenQueryHandler : IRequestHandler<GenerateJwtTokenQuery, Token>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Domain.Entities.User> _userManager;

        public GenerateJwtTokenQueryHandler(IConfiguration configuration, UserManager<Domain.Entities.User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<Token> Handle(GenerateJwtTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null) throw new Exception($"User \"{request.Username}\" not found!");

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.First())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(double.Parse(_configuration["Jwt:Lifetime"])),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );

            return new Token()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo,
                Role = roles.First()
            };
        }
    }
}
