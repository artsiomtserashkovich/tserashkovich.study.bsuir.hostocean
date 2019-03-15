using HostOcean.Application.Queue.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class UserQueueController : BaseController
    {
        public UserQueueController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("take")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<OkResult> Take([FromBody]TakeQueueCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
