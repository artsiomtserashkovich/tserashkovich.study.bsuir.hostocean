using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using HostOcean.Domain.Entities;
using HostOcean.Persistence.Interfaces;
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
            private readonly UserManager<User> _userManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;

            public CreateUserCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
            {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    GroupId = request.GroupId
                };

                var group = _unitOfWork.Groups.Get(request.GroupId);
                if (group == null)
                {
                    var validationFailure = new ValidationFailure("Group", "Group doesn't exists");
                    throw new ValidationException(new[] { validationFailure });
                }


                var user = await _userManager.FindByNameAsync(entity.UserName);
                if (user != null)
                {
                    var validationFailure = new ValidationFailure("Username", "User already exists");
                    throw new ValidationException(new[] { validationFailure });
                }

                var creationResult = await _userManager.CreateAsync(entity);
                if (!creationResult.Succeeded) throw new NotImplementedException(creationResult.ToString());

                var roleResult = await _userManager.AddToRoleAsync(entity, "User");
                if (!roleResult.Succeeded) throw new NotImplementedException(roleResult.ToString());

                var result = await _userManager.AddPasswordAsync(entity, request.Password);

                if (!result.Succeeded) throw new NotImplementedException(result.ToString());

                return Unit.Value;
            }
        }
    }
}