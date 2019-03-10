using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query.Ping
{
    class PingQueryHandler : IRequestHandler<PingQuery,Pong>
    {
        public Task<Pong> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            var pong = new Pong
            {
                Message = "Pong."
            };
            return Task.FromResult(pong);
        }
    }
}
