using AutoMapper;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.Requests.Models;
using HostOcean.Application.Users.Queries;
using HostOcean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostOcean.Application.Requests.Commands.CreateSwapRequest
{
    public class CreateSwapRequestCommand : IRequest<RequestModel>
    {
        public string ReceiverUserId { get; set; }
        public string QueueId { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<CreateSwapRequestCommand, RequestModel>
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

            public async Task<RequestModel> Handle(CreateSwapRequestCommand request, CancellationToken cancellationToken)
            {
                var user = await _mediator.Send(new GetCurrentUserQuery());

                var targetUser = await _unitOfWork.UserManager.FindByIdAsync(request.ReceiverUserId);
                if (targetUser == null)
                {
                    throw new NotImplementedException();
                }

                var queue = _unitOfWork.Queues.Get(request.QueueId);
                if (queue == null)
                {
                    throw new NotImplementedException();
                }

                var entity = new Request
                {
                    Id = Guid.NewGuid().ToString(),
                    State = RequestState.Pending,
                    Type = RequestType.PlaceSwap,
                    CreatedOn = DateTime.Now,
                    CreatorUserId = user.Id,
                    ReceiverUserId = request.ReceiverUserId,
                    QueueId = request.QueueId
                };

                _unitOfWork.Requests.Add(entity);
                await _unitOfWork.SaveAsync();

                var model = _mapper.Map<Request, RequestModel>(entity);

                return model;
            }
        }
    }
}