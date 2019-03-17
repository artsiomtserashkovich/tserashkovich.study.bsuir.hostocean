using AutoMapper;
using HostOcean.Application.LaboratoryWorks.Models;
using HostOcean.Application.LaboratoryWorks.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class LabworksController : BaseController
    {
        private readonly IMapper _mapper;

        public LabworksController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet("upcoming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IEnumerable<LaboratoryWorkModel>))]
        public async Task<IActionResult> GetUpcomingLabs(string groupId)
        {
            var upcomingLabs = await Mediator.Send(new GetUpcomingLabworksQuery() { GroupId = groupId } );

            return Ok(upcomingLabs);
        }
    }
}
