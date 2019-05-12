using AutoMapper;
using HostOcean.Application.Tokens.Models;
using HostOcean.Application.Tokens.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class TokenController : BaseController
    {
        public TokenController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(JwtToken))]
        public async Task<IActionResult> Refresh([FromBody] JwtToken token)
        {
            var result = await Mediator.Send(new RefreshTokenQuery { Token = token });
            return Ok(result);
        }
    }
}
