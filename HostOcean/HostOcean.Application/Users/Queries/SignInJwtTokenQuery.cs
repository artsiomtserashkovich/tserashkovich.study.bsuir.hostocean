using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Tokens.Models;
using HostOcean.Application.Tokens.Queries;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Users.Queries
{
    public class SignInJwtTokenQuery : IRequest<JwtToken>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class SignInJwtTokenQueryHandler : IRequestHandler<SignInJwtTokenQuery, JwtToken>
        {
            private readonly JwtSettings _jwtSettings;
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IMediator _mediator;

            public SignInJwtTokenQueryHandler(
                IOptions<JwtSettings> jwtSettingsOptions,
                SignInManager<User> signInManager,
                UserManager<User> userManager,
                IMediator mediator)
            {
                _jwtSettings = jwtSettingsOptions.Value;
                _userManager = userManager;
                _signInManager = signInManager;
                _mediator = mediator;
            }

            public async Task<JwtToken> Handle(SignInJwtTokenQuery request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.Username);

                if (user == null) throw new NotFoundException(nameof(User), request.Username);

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (!result.Succeeded)
                {
                    throw new Exception("Invalid password");
                }

                var token = await _mediator.Send(new GetJwtTokenQuery { Username = request.Username });
                token.RefreshToken = user.RefreshToken;

                return token;
            }
        }
    }
}