using HostOcean.Infrastructure;
using MediatR;

namespace HostOcean.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ServiceResult>
    {
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}