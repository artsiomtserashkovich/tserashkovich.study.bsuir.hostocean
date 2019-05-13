using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HostOcean.Application.Queues.Models;
using HostOcean.Application.Queues.Queries;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class QueueController : BaseController
    {
        public QueueController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
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
