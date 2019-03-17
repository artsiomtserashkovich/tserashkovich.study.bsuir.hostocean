using System;
using System.Threading.Tasks;
using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Groups.Commands;
using HostOcean.Application.Interfaces.Infrastructure;
using HostOcean.Application.Interfaces.Persistence;
using Microsoft.Extensions.Options;

namespace HostOcean.Infrastructure.Hangfire.SheduleCommandInitializer
{
    public class SheduleCommandsInitializer : ISheduleCommandsInitializer
    {
        private readonly ICommandsSheduler _commandsSheduler;
        private readonly IHostOceanDataBaseContextInitializer _hostOceanDataBaseContextInitializer;
        private readonly HangfireSettings _hangfireSettings;

        public SheduleCommandsInitializer(
            ICommandsSheduler commandsSheduler,
            IOptions<HangfireSettings> hangfireSettingsOption,
            IHostOceanDataBaseContextInitializer hostOceanDataBaseContextInitializer)
        {
            _commandsSheduler = commandsSheduler;
            _hostOceanDataBaseContextInitializer = hostOceanDataBaseContextInitializer;
            _hangfireSettings = hangfireSettingsOption.Value;
        }

        public void InitializeSheduleCommands()
        {
            _commandsSheduler.ExecuteExpressionWithDelay(
                () => _hostOceanDataBaseContextInitializer.InitializeMigration(), TimeSpan.FromSeconds(10));

            _commandsSheduler.ExecuteExpressionWithDelay(() => _hostOceanDataBaseContextInitializer.SeedDataBase(),
                TimeSpan.FromSeconds(40));

            _commandsSheduler.ExecuteWithDelay(new CloneBsuirGroupsStorageCommand(), TimeSpan.FromMinutes(2));

            _commandsSheduler.ExecutesByCronExpression(new CloneBsuirGroupsStorageCommand(), Guid.NewGuid().ToString(),
                _hangfireSettings.GroupSeedingCron, "Update Group list from Bsuir IIS.");
        }
    }
}
