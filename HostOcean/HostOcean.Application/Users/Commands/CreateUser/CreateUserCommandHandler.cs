using System;
using System.Threading;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;
using HostOcean.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HostOcean.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(UserManager<User> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<ServiceResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                GroupId = request.GroupId
            };

            try
            {
                var user = await _userManager.FindByNameAsync(entity.UserName);
                if (user != null) return new ServiceResult("User already exists");

                var creationResult = await _userManager.CreateAsync(entity);

                if (!creationResult.Succeeded) new ServiceResult(creationResult);

                var result = await _userManager.AddPasswordAsync(entity, request.Password);

                return new ServiceResult(result);
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}