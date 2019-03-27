using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HostOcean.Persistence.Seed
{
    public class HostOceanDataBaseContextInitializer : IHostOceanDataBaseContextInitializer
    {
        private User _defaultDebugAdminUser;
        private Group _defaultDebugGroup;
        private LaboratoryWork _defaultDebugLaboratoryWork;
        private LaboratoryWorkEvent _defaultDebugLaboratoryWorkEvent;
        private Queue _defaultDebugQueue;

        private RoleManager<IdentityRole> _roleManager;
        private readonly HostOceanDbContext _dbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HostOceanDataBaseContextInitializer(
            HostOceanDbContext dbContext,
            IHostingEnvironment hostingEnvironment,
            RoleManager<IdentityRole> roleManager
        )
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
        }
        public async Task SeedDataBase()
        {
            if (_hostingEnvironment.IsDevelopment())
                await SeedDataBaseWithDebugDefaultValues();
            else
                await SeedDataBaseWithDefaultValues();

            await _dbContext.SaveChangesAsync();
        }

        public async Task InitializeMigration()
        {
            try
            {
                await _dbContext.Database.MigrateAsync();
            }
            catch (SqlException sqlException) when (sqlException.Number == 1801)
            {
                //Ignored. Reason: Database already exist.
            }
        }

        private async Task SeedDataBaseWithDefaultValues()
        {
            await SeedRoles();
        }

        private async Task SeedDataBaseWithDebugDefaultValues()
        {
            await SeedRoles();
            await SeedDebugGroups();
            await SeedDebugLaboratoryworks();
            await SeedDebugEvents();
            await SeedDebugUsers();
            await SeedDebugQueues();
        }

        private async Task SeedRoles()
        {
            if (!(await _dbContext.Roles.AnyAsync()))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        private async Task SeedDebugGroups()
        {
            if (!(await _dbContext.Groups.AnyAsync()))
            {
                _defaultDebugGroup = new Group()
                {
                    Name = "Admin Debug Group",
                    CalendarId = "dla8vgkme6547ks8gr03uekkm8@group.calendar.google.com"
                };

                await _dbContext.Groups.AddAsync(_defaultDebugGroup);
            }
        }

        public async Task SeedDebugLaboratoryworks()
        {
            if (!_dbContext.LaboratoryWorks.Any())
            {
                _defaultDebugLaboratoryWork = new LaboratoryWork()
                {
                    Title = "Admin Debug Laboratory Work",
                    Group = _defaultDebugGroup
                };

                await _dbContext.LaboratoryWorks.AddAsync(_defaultDebugLaboratoryWork);
            }
        }

        public async Task SeedDebugEvents()
        {
            if (!_dbContext.LaboratoryWorkEvents.Any())
            {
                _defaultDebugLaboratoryWorkEvent = new LaboratoryWorkEvent()
                {
                    Queue = _defaultDebugQueue,
                    LaboratoryWork = _defaultDebugLaboratoryWork,
                    StartDate = new DateTime(),
                    RegistrationStartedAt = new DateTime()
                };

                await _dbContext.LaboratoryWorks.AddAsync(_defaultDebugLaboratoryWork);
            }
        }

        private async Task SeedDebugUsers()
        {
            if (!_dbContext.Users.Any())
            {
                _defaultDebugAdminUser = new User()
                {
                    UserName = "admin",
                    Group = _defaultDebugGroup,
                };

                await _dbContext.Users.AddAsync(_defaultDebugAdminUser);
            }
        }

        private async Task SeedDebugQueues()
        {
            if (!_dbContext.Queues.Any())
            {
                _defaultDebugQueue = new Queue()
                {
                    CreatedOn = DateTime.Now,
                    RegistrationStart = DateTime.Now.AddHours(6),
                    LaboratoryWorkEvent = _defaultDebugLaboratoryWorkEvent,
                };

                await _dbContext.Queues.AddAsync(_defaultDebugQueue);
            }
        }
    }
}
