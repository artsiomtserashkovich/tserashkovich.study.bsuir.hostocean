using System;
using HostOcean.Application.ApplicationSettings;
using HostOcean.Application.Groups.Commands;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Application.LaboratoryWorks;
using Microsoft.Extensions.Options;

namespace HostOcean.Infrastructure.Hangfire.SheduleCommandInitializer
{
    public class SheduleCommandsInitializer : ISheduleCommandsInitializer
    {
        private readonly IStartupCommandSheduler _commandsSheduler;
        private readonly IHostOceanDataBaseContextInitializer _hostOceanDataBaseContextInitializer;
        private readonly HangfireSettings _hangfireSettings;

        public SheduleCommandsInitializer(
            IStartupCommandSheduler commandsSheduler,
            IOptions<HangfireSettings> hangfireSettingsOption,
            IHostOceanDataBaseContextInitializer hostOceanDataBaseContextInitializer)
        {
            _commandsSheduler = commandsSheduler;
            _hostOceanDataBaseContextInitializer = hostOceanDataBaseContextInitializer;
            _hangfireSettings = hangfireSettingsOption.Value;
        }

        public void InitializeSheduleCommands()
        {
            var migrateExpressionId = _commandsSheduler.ExecuteExpressionWithDelay(
                () => _hostOceanDataBaseContextInitializer.InitializeMigration(), TimeSpan.FromSeconds(10));

            var initializeDatabaseExpressionId = _commandsSheduler.ExecuteExpressionAfterSuccessPrevious(() => 
                _hostOceanDataBaseContextInitializer.SeedDataBase(), migrateExpressionId);

            _commandsSheduler.ExecuteAfterSuccessParentCommand(new MigrateBsuirGroupsCommand(), 
                initializeDatabaseExpressionId, "Clone Group list from Bsuir IIS.");

            _commandsSheduler.ExecutesByCronExpression(new MigrateBsuirGroupsCommand(), Guid.NewGuid().ToString(),
                _hangfireSettings.GroupSeedingCron, "Update Group list from Bsuir IIS.");

            _commandsSheduler.ExecutesByCronExpression(new MigrateLaboratoryWorksCommand
                    {
                        MigratePeriod = TimeSpan.FromDays(7)
                    },
                    Guid.NewGuid().ToString(),
                    _hangfireSettings.LaboratoryWorkSeedingCron,
                    "Get new laboratory works from Google Calendar."
                );
        }
    }
}
