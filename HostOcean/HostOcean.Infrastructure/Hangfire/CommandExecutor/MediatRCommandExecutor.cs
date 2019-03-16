using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using HostOcean.Application.Ping.Query.Ping;
using MediatR;
using Newtonsoft.Json;

namespace HostOcean.Infrastructure.Hangfire.CommandExecutor
{
    public class MediatRCommandExecutor: ICommandExecutor
    {
        private readonly IMediator _mediator;

        public MediatRCommandExecutor(IMediator mediator)
        {
            _mediator = mediator;
        }
        [DisplayName("Processing command {0}")]
        public async Task ExecuteCommand(SerializedScheduleCommand command)
        {
            var commandType = Assembly.GetAssembly(typeof(PingQuery)).GetType(command.CommandTypeName);
            if (commandType != null)
            {
                var mediatrCommand = JsonConvert.DeserializeObject(command.SerializedCommand, commandType) as IRequest;
                await _mediator.Send(mediatrCommand);
            }
        }
    }
}
