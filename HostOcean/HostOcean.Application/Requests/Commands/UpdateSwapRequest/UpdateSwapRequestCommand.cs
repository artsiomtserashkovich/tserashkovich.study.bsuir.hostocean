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
    public class UpdateSwapRequestCommand : IRequest<RequestModel>
    {
        public string Id { get; set; }
        public RequestState State { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<UpdateSwapRequestCommand, RequestModel>
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

            public async Task<RequestModel> Handle(UpdateSwapRequestCommand request, CancellationToken cancellationToken)
            {
                var user = await _mediator.Send(new GetCurrentUserQuery());

                var entity = _unitOfWork.Requests.Get(request.Id);
                if (entity == null || entity.State != 0)
                {
                    throw new NotImplementedException();
                }

                entity.State = request.State;

                if (request.State == RequestState.Accepted)
                {
                    var creatorUserQueue = _unitOfWork.UserQueues.SingleOrDefault(uq => uq.UserId == entity.CreatorUserId && uq.QueueId == entity.QueueId);
                    var receiverUserQueue = _unitOfWork.UserQueues.SingleOrDefault(uq => uq.UserId == entity.ReceiverUserId && uq.QueueId == entity.QueueId);

                    if (creatorUserQueue == null || receiverUserQueue == null)
                    {
                        entity.State = RequestState.Expired;
                    }
                    else
                    {
                        var updatedCreatorUserQueue = _mapper.Map<UserQueue, UserQueue>(creatorUserQueue);
                        var updatedReceiverUserQueue = _mapper.Map<UserQueue, UserQueue>(receiverUserQueue);

                        _unitOfWork.UserQueues.Remove(creatorUserQueue);
                        _unitOfWork.UserQueues.Remove(receiverUserQueue);

                        await _unitOfWork.SaveAsync();

                        var tempUserId = updatedCreatorUserQueue.UserId;

                        updatedCreatorUserQueue.UserId = updatedReceiverUserQueue.UserId;
                        updatedReceiverUserQueue.UserId = tempUserId;

                        _unitOfWork.UserQueues.Add(updatedCreatorUserQueue);
                        _unitOfWork.UserQueues.Add(updatedReceiverUserQueue);

                        await _unitOfWork.SaveAsync();
                    }
                }

                var model = _mapper.Map<Request, RequestModel>(entity);

                _unitOfWork.Requests.Update(entity);
                await _unitOfWork.SaveAsync();

                return model;
            }
        }
    }
}