using AutoMapper;
using HostOcean.Application.Group.Models;
using HostOcean.Application.Group.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HostOcean.Api.Controllers
{
    public class GroupsController : BaseController
    {
        private readonly IMapper _mapper;

        public GroupsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(IEnumerable<GroupModel>))]
        public async Task<IActionResult> GetAll()
        {
            var groups = await Mediator.Send(new GetGroupsQuery());

            return Ok(groups);
        }
    }
}
