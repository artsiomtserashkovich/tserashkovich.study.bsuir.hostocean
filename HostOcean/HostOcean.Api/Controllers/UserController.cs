using AutoMapper;
using HostOcean.Application.User.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
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