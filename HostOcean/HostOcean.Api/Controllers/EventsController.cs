using AutoMapper;
using HostOcean.Application.Events.Models;
using HostOcean.Application.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class EventsController : BaseController
    {
        public EventsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [Authorize]
        [HttpGet("upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IEnumerable<LaboratoryWorkEventModel>))]
        public async Task<IActionResult> GetUpcomingLabs(string groupId)
        {
            var upcomingLabs = await Mediator.Send(new GetUpcomingEventsQuery() { GroupId = groupId });

            return Ok(upcomingLabs);
        }
    }
}
