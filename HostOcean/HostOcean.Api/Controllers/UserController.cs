using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HostOcean.Application.Users.Commands.CreateUser;
using HostOcean.Application.Users.Models;
using HostOcean.Application.Users.Queries;

namespace HostOcean.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<OkResult> Create([FromBody] CreateUserCommand command)
        { 
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("signin")]
        public async Task<JwtToken> SignIn([FromBody] SignInJwtTokenQuery signInQuery)
        {
            return await Mediator.Send(signInQuery);
        }
    }
}