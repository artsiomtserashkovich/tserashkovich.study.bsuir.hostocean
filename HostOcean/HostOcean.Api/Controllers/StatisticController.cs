using System.Collections.Generic;
using System.Threading.Tasks;
using HostOcean.Application.Statistics.Models;
using HostOcean.Application.Statistics.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostOcean.Api.Controllers
{
    public class StatisticController : BaseController
    {
        public StatisticController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<StatisticModel> GetStatistic(
            [FromQuery] GetStatisticForPeriodQuery query) =>
                await Mediator.Send(query);
        
    }
}