using AutoMapper;
using HostOcean.Api.Hubs;
using HostOcean.Application.Requests.Commands.CreateSwapRequest;
using HostOcean.Application.Requests.Queries;
using HostOcean.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class RequestsController : BaseController
    {
        private readonly IHubContext<HostOceanHub> _hubContext;

        public RequestsController(IMediator mediator, IMapper mapper, IHubContext<HostOceanHub> hubContext) : base(mediator, mapper)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRequests()
        {
            var requests = await Mediator.Send(new GetUsersRequestsQuery());

            return Ok(requests);
        }

        [HttpPost("swap")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostSwap([FromBody] CreateSwapRequestCommand command)
        {
            var model = await Mediator.Send(command);

            await _hubContext.Clients.User(model.ReceiverUserId).SendAsync("onRequestCreated", model);

            return Ok(model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutSwap([FromBody] UpdateSwapRequestCommand command)
        {
            var model = await Mediator.Send(command);

            await _hubContext.Clients.Users(new[] { model.ReceiverUserId, model.CreatorUserId }).SendAsync("onRequestUpdated", model);

            if (model.State == Domain.Entities.RequestState.Accepted)
            {
                var user = await Mediator.Send(new GetCurrentUserQuery());
                await _hubContext.Clients.Group(user.GroupId).SendAsync("onUserQueuesSwap", model);
            }

            return Ok(model);
        }
    }
}
