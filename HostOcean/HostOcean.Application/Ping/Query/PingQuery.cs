using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query
{
    public class PingQuery: IRequest<Pong>
    {
    }
}