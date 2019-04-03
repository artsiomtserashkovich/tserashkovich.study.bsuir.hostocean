using System.Threading.Tasks;
using HostOcean.Application.Statistics.Models;
using HostOcean.Application.Statistics.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HostOcean.Api.Controllers
{
    [Authorize]
    public class StatisticController : BaseController
    {
        public StatisticController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<StatisticModel> GetStatistic(
            [FromQuery] GetCurrentUserStatisticQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}