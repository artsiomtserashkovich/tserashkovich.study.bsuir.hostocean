using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HostOcean.Application.Users.Commands.CreateUser;
using HostOcean.Application.Users.Models;
using HostOcean.Application.Users.Queries;
using FluentValidation;
using System.Collections.Generic;

namespace HostOcean.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(JwtToken))]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                await Mediator.Send(command);

                var signInQuery = new SignInJwtTokenQuery { Username = command.UserName, Password = command.Password };
                var token = await Mediator.Send(signInQuery);
                return Ok(token);
            }
            catch(ValidationException ex)
            {
                //TODO: move to handler

                var dict = new Dictionary<string, string>();
                foreach (var error in ex.Errors)
                {
                    dict.TryAdd(error.PropertyName, error.ErrorMessage);
                }
                
                return BadRequest(new { Errors = dict });
            }
        }
        
        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(JwtToken))]
        public async Task<IActionResult> SignIn([FromBody] SignInJwtTokenQuery signInQuery)
        {
            return Ok(await Mediator.Send(signInQuery));
        }
    }
}