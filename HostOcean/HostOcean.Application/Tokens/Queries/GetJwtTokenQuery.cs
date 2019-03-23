using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Tokens.Models;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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
    public class GetJwtTokenQuery : IRequest<JwtToken>
    {
        public string Username { get; set; }

        public class GetJwtTokenQueryHandler : IRequestHandler<GetJwtTokenQuery, JwtToken>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IMediator _mediator;
            private readonly JwtSettings _jwtSettings;

            public GetJwtTokenQueryHandler(IOptions<JwtSettings> jwtSettingsOptions, UserManager<User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMediator mediator)
            {
                _jwtSettings = jwtSettingsOptions.Value;
                _userManager = userManager;
                _unitOfWork = unitOfWork;
                _httpContextAccessor = httpContextAccessor;
                _mediator = mediator;
            }

            public async Task<JwtToken> Handle(GetJwtTokenQuery request, CancellationToken cancellationToken)
            {
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
                    Expires = token.ValidTo.ToUniversalTime(),
                    Role = roles.First()
                };
            }
        }
    }
}