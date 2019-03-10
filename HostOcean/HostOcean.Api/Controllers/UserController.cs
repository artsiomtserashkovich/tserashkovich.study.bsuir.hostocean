using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        { 
            await Mediator.Send(command);
            return Ok();
        }

        public async Task<JwtToken> SignIn([FromBody] SignInJwtTokenQuery signInJwtTokenQuery)
        {
            return await Mediator.Send(signInJwtTokenQuery);
        }
    }
}