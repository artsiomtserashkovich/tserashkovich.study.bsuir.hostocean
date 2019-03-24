using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HostOcean.Application.Groups.Models;
using HostOcean.Application.Groups.Queries;
using Microsoft.AspNetCore.Authorization;

namespace HostOcean.Api.Controllers
{
    public class GroupsController : BaseController
    {
        public GroupsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
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
