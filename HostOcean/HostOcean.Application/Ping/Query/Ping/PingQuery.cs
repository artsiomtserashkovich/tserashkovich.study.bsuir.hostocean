using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query.Ping
{
    public class PingQuery: IRequest<Pong>
    {
    }
}