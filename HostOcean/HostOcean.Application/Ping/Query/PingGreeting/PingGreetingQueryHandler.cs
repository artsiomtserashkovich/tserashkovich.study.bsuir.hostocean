using System.Threading;
using System.Threading.Tasks;
using HostOcean.Application.Ping.Model;
using MediatR;

namespace HostOcean.Application.Ping.Query.PingGreeting
{
    class PingGreetingQueryHandler : IRequestHandler<PingGreetingQuery,Pong>
    {
        public Task<Pong> Handle(PingGreetingQuery request, CancellationToken cancellationToken)
        {
            var pong = new Pong
            {
                Message = "Pong.Hello " + request.Name + "."
            };
            return Task.FromResult(pong);
        }
    }
}
