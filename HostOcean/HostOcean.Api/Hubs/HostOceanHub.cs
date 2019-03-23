using System;
using System.Threading.Tasks;
using HostOcean.Application.Queues.Commands;
using HostOcean.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace HostOcean.Api.Hubs
{
    [Authorize]
    public class HostOceanHub : Hub
    {
        private readonly IMediator _mediator;

        public HostOceanHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _mediator.Send(new GetCurrentUserQuery());
            await Groups.AddToGroupAsync(Context.ConnectionId, user.GroupId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = await _mediator.Send(new GetCurrentUserQuery());
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.GroupId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
