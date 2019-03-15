using System;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HostOcean.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
        {
            private readonly UserManager<Domain.Entities.User> _userManager;

            public CreateUserCommandHandler(UserManager<Domain.Entities.User> userManager)
            {
                _userManager = userManager;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    GroupId = request.GroupId
                };

                var user = await _userManager.FindByNameAsync(entity.UserName);
                if (user != null) new NotImplementedException("User already exists");

                var creationResult = await _userManager.CreateAsync(entity);

                if (!creationResult.Succeeded) new NotImplementedException(creationResult.ToString());

                var result = await _userManager.AddPasswordAsync(entity, request.Password);

                if (!result.Succeeded) new NotImplementedException(result.ToString());

                return Unit.Value;
            }
        }
    }
}