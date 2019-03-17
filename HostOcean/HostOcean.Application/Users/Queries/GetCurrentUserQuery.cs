using AutoMapper;
using HostOcean.Application.Exceptions;
using HostOcean.Application.Users.Models;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Users.Queries
{
    public class GetCurrentUserQuery : IRequest<UserModel>
    {
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserModel>
        {
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetCurrentUserQueryHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<UserModel> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new NotFoundException("User", userId);

                var model = _mapper.Map<User, UserModel>(user);

                return model;
            }
        }
    }
}
