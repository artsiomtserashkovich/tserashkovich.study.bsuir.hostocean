using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using HostOcean.Application.Interfaces.Persistence;
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
            private readonly IUnitOfWork _unitOfWork;

            private string GenerateRefreshToken()
            {
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }

            public CreateUserCommandHandler(UserManager<Domain.Entities.User> userManager, IUnitOfWork unitOfWork)
            {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    GroupId = request.GroupId,
                    RefreshToken = GenerateRefreshToken()
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

                return await Unit.Task;
            }
        }
    }
}