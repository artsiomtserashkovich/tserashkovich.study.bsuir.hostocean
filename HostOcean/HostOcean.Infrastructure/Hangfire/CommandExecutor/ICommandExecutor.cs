using System.ComponentModel;
using System.Threading.Tasks;

namespace HostOcean.Infrastructure.Hangfire.CommandExecutor
{
    public interface ICommandExecutor
    {
        [DisplayName("Processing command {0}")]
        Task ExecuteCommand(SerializedScheduleCommand command);
    }
}
