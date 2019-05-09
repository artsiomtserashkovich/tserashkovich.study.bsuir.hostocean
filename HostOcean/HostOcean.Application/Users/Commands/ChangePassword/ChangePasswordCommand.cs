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

namespace HostOcean.Application.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirmation { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public ChangePasswordCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
            {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _mediator.Send(new GetCurrentUserQuery());
                if (user == null)
                {
                    var validationFailure = new ValidationFailure("User", "User doesn't exists");
                    throw new ValidationException(new[] { validationFailure });
                }

                var userEntity = await _userManager.FindByIdAsync(user.Id);

                var result = await _userManager.ChangePasswordAsync(userEntity, request.CurrentPassword, request.NewPassword);
                if (!result.Succeeded)
                {
                    var validationFailure = new ValidationFailure("Password", "Failed to update password");
                    throw new ValidationException(new[] { validationFailure });
                }

                return await Unit.Task;
            }
        }
    }
}