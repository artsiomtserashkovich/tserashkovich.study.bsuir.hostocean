using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HostOcean.Application.Queues.Commands;
using Microsoft.AspNetCore.SignalR;
using HostOcean.Api.Hubs;
using HostOcean.Application.UserQueues.Queries;
using Microsoft.AspNetCore.Authorization;
using HostOcean.Application.Users.Queries;
using AutoMapper;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class UserQueueController : BaseController
    {
        private readonly IHubContext<HostOceanHub> _hubContext;

        public UserQueueController(IMediator mediator, IMapper mapper, IHubContext<HostOceanHub> hubContext) : base(mediator, mapper)
        {
            _hubContext = hubContext;
        }

        [HttpPost("take")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<OkResult> Take([FromBody]TakeQueueCommand command)
        {
            await Mediator.Send(command);

            var model = await Mediator.Send(new GetUserQueueQuery()
            {
                UserId = command.UserId,
                QueueId = command.QueueId
            });

            var user = await Mediator.Send(new GetCurrentUserQuery());

            await _hubContext.Clients.Group(user.GroupId).SendAsync("onUserTakeQueue", model);
            return Ok();
        }

        [HttpPost("leave")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<OkResult> Leave([FromBody]LeaveQueueCommand command)
        {
            await Mediator.Send(command);

            var user = await Mediator.Send(new GetCurrentUserQuery());

            await _hubContext.Clients.Group(user.GroupId).SendAsync("onUserLeftQueue", command);
            return Ok();
        }
    }
}
