using HostOcean.Application.Queue.Models;
using HostOcean.Application.Queue.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class QueueController : BaseController
    {
        public QueueController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueueModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await Mediator.Send(new GetQueueQuery() { Id = id });

            if (!result.IsSucceeded)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Result);
        }
    }
}
