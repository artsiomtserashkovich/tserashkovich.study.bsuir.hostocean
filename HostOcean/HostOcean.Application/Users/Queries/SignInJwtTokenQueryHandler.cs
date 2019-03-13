using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Infrastructure.AppSettings;
using HostOcean.Application.Users.Models;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HostOcean.Application.Users.Queries
{
    public class SignInJwtTokenQueryHandler : IRequestHandler<SignInJwtTokenQuery, JwtToken>
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;

        public SignInJwtTokenQueryHandler(IOptions<JwtSettings> jwtSettingsOptions, UserManager<User> userManager)
        {
            _jwtSettings = jwtSettingsOptions.Value;
            _userManager = userManager;
        }

        public async Task<JwtToken> Handle(SignInJwtTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null) throw new NotFoundException(nameof(User), request.Username);

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roles.First())
            };

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddHours(_jwtSettings.Lifetime),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtToken
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo,
                Role = roles.First()
            };
        }
    }
}