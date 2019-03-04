﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.User.Create
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, Unit>
        {
            private readonly UserManager<Domain.Entities.User> _userManager;
            private readonly IMediator _mediator;

            public Handler( UserManager<Domain.Entities.User> userManager, IMediator mediator)
            {
                _userManager = userManager;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    GroupId = request.GroupId
                };

                var creationResult = await _userManager.CreateAsync(entity);

                if (creationResult.Succeeded)
                {
                    var result = await _userManager.AddPasswordAsync(entity, request.Password);

                    if (result.Succeeded)
                    {
                        await _mediator.Publish(new UserCreated());
                    }
                }

                return Unit.Value;
            }
        }
    }
}
