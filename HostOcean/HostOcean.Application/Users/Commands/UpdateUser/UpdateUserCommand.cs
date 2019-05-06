using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Users.Models;
using HostOcean.Application.Users.Queries;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HostOcean.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
            {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<UserModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var group = _unitOfWork.Groups.SingleOrDefault(g => g.Name == request.Group);
                if (group == null)
                {
                    var validationFailure = new ValidationFailure("Group", "Group doesn't exists");
                    throw new ValidationException(new[] { validationFailure });
                }

                var entity = await _userManager.FindByIdAsync(request.Id);
                if (entity == null)
                {
                    var validationFailure = new ValidationFailure("User", "User doesn't exists");
                    throw new ValidationException(new[] { validationFailure });
                }

                var newUser = await _userManager.FindByNameAsync(request.UserName);
                if (newUser?.Id != entity.Id)
                {
                    var validationFailure = new ValidationFailure("UserName", "Username already exists");
                    throw new ValidationException(new[] { validationFailure });
                }

                _mapper.Map(request, entity);
                entity.Group = group;

                var result = await _userManager.UpdateAsync(entity);

                if (!result.Succeeded) throw new NotImplementedException(result.ToString());

                var model = _mapper.Map<User, UserModel>(await _userManager.FindByIdAsync(entity.Id));

                return model;
            }
        }
    }
}