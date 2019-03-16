using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HostOcean.Application.Queues.Models;
using HostOcean.Application.Queues.Queries;

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

            return Ok(result);
        }
    }
}
