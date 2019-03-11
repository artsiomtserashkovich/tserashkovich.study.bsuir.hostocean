using HostOcean.Application.Users.Models;
using MediatR;

namespace HostOcean.Application.Users.Queries
{
    public class SignInJwtTokenQuery : IRequest<JwtToken>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}