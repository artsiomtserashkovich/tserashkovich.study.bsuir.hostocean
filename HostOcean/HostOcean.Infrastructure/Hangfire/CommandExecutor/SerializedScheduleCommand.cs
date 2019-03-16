using System.Linq;

namespace HostOcean.Infrastructure.Hangfire.CommandExecutor
{
    public class SerializedScheduleCommand
    {
        public string CommandTypeName { get; }
        public string SerializedCommand { get; }
        private readonly string _description;

        public SerializedScheduleCommand(string commandTypeName,string serializedCommand, string description = null)
        {
            CommandTypeName = commandTypeName;
            SerializedCommand = serializedCommand;
            _description = description;
        }

        public override string ToString()
        {
            return $"{CommandTypeName.Split('.').Last()} {_description}";
        }
    }
}
