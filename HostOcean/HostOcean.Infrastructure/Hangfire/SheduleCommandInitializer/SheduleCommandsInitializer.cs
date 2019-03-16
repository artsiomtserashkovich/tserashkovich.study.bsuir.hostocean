using System;
using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Groups.Commands;
using HostOcean.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Options;

namespace HostOcean.Infrastructure.Hangfire.SheduleCommandInitializer
{
    public class SheduleCommandsInitializer : ISheduleCommandsInitializer
    {
        private readonly ICommandsSheduler _commandsSheduler;
        private readonly HangfireSettings _hangfireSettings;

        public SheduleCommandsInitializer(ICommandsSheduler commandsSheduler,
            IOptions<HangfireSettings> hangfireSettingsOption)
        {
            _commandsSheduler = commandsSheduler;
            _hangfireSettings = hangfireSettingsOption.Value;
        }

        public void InitializeSheduleCommands()
        {
            _commandsSheduler.ExecuteWithDelay(new CloneBsuirGroupsStorageCommand(), TimeSpan.FromSeconds(30));

            _commandsSheduler.ExecutesByCronExpression(new CloneBsuirGroupsStorageCommand(), Guid.NewGuid().ToString(),
                _hangfireSettings.GroupSeedingCron, "Update Group list from Bsuir IIS.");
        }
    }
}
