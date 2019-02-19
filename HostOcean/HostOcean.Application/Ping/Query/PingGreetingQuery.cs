using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query
{
    public class PingGreetingQuery : IRequest<Pong>
    {
        public string Name { get; set; }
    }
}
