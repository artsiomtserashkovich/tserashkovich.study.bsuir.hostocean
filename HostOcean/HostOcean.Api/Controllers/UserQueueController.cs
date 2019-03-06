using AutoMapper;
using HostOcean.Application.Queue.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class UserQueueController : BaseController
    {
        private readonly IMapper _mapper;

        public UserQueueController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost("take")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Take([FromBody]TakeQueueCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result.IsSucceeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
