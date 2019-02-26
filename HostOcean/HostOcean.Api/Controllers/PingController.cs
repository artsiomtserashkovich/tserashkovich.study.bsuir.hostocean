using System.Threading.Tasks;
using HostOcean.Application.Ping.Model;
using HostOcean.Application.Ping.Query.Ping;
using HostOcean.Application.Ping.Query.PingGreeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostOcean.Api.Controllers
{
    public class PingController : BaseController
    {
        public PingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<Pong> Get()
        {
            return await Mediator.Send(new PingQuery());
        }

        [HttpGet("greetingping")] 
        public async Task<Pong> Get([FromQuery] PingGreetingQuery pingGreetingQuery)
        {
            return await Mediator.Send(pingGreetingQuery);
        }
    }
}