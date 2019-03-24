using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Tokens.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Tokens.Queries
{
    public class RefreshTokenQuery : IRequest<JwtToken>
    {
        public JwtToken Token { get; set; }

        public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, JwtToken>
        {
            private readonly UserManager<Domain.Entities.User> _userManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IMediator _mediator;

            public RefreshTokenQueryHandler(UserManager<Domain.Entities.User> userManager, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMediator mediator)
            {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
                _httpContextAccessor = httpContextAccessor;
                _mediator = mediator;
            }

            public async Task<JwtToken> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
                var user = await _unitOfWork.UserManager.FindByNameAsync(userName);

                if (user.RefreshToken != request.Token.RefreshToken)
                {
                    throw new Exception("RefreshToken is not valid");
                }

                var token = await _mediator.Send(new GetJwtTokenQuery { Username = userName });
                token.RefreshToken = user.RefreshToken;

                return token;
            }
        }
    }
}