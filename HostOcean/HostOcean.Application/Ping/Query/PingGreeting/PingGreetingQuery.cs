using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query.PingGreeting
{
    public class PingGreetingQuery : IRequest<Pong>
    {
        public string Name { get; set; }
    }
}
