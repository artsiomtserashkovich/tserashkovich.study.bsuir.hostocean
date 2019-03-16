using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;
using HostOcean.Persistence.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Persistence.Seed
{
    public class HostOceanDataBaseContextInitializer : IHostOceanDataBaseContextInitializer
    {
        private User _defaultDebugAdminUser;
        private Group _defaultDebugGroup;
        private LaboratoryWork _defaultDebugLaboratoryWork;
        private Queue _defaultDebugQueue;

        private RoleManager<IdentityRole> _roleManager;
        private readonly HostOceanDataBaseContext _dataBaseContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HostOceanDataBaseContextInitializer(
            HostOceanDataBaseContext dataBaseContext,
            IHostingEnvironment hostingEnvironment,
            RoleManager<IdentityRole> roleManager
        )
        {
            _dataBaseContext = dataBaseContext;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
        }
        public async Task Initialize()
        {
            await InitializeMigration();
            if (_hostingEnvironment.IsDevelopment())
                await SeedDataBaseWithDebugDefaultValues();
            else
                await SeedDataBaseWithDefaultValues();

            await _dataBaseContext.SaveChangesAsync();
        }

        private async Task InitializeMigration()
        {
            try
            {
                await _dataBaseContext.Database.MigrateAsync();
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
            await SeedDebugUsers();
            await SeedDebugQueues();
        }

        private async Task SeedRoles()
        {
            if (! (await _dataBaseContext.Roles.AnyAsync()))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        private async Task SeedDebugGroups()
        {
            if (!(await _dataBaseContext.Groups.AnyAsync()))
            {
                _defaultDebugGroup = new Group()
                {
                    Name = "Admin Debug Group",
                    CalendarId = "dla8vgkme6547ks8gr03uekkm8@group.calendar.google.com"
                };

                await _dataBaseContext.Groups.AddAsync(_defaultDebugGroup);
            }
        }

        public async Task SeedDebugLaboratoryworks()
        {
            if (!_dataBaseContext.LaboratoryWorks.Any())
            {
                _defaultDebugLaboratoryWork = new LaboratoryWork()
                {
                    Title = "Admin Debug Laboratory Work",
                    Group = _defaultDebugGroup
                };

                await _dataBaseContext.LaboratoryWorks.AddAsync(_defaultDebugLaboratoryWork);
            }
        }

        private async Task SeedDebugUsers()
        {
            if (!_dataBaseContext.Users.Any())
            {
                _defaultDebugAdminUser = new User()
                {
                    UserName = "admin",
                    Group = _defaultDebugGroup,
                };

                await _dataBaseContext.Users.AddAsync(_defaultDebugAdminUser);
            }
        }

        private async Task SeedDebugQueues()
        {
            if (!_dataBaseContext.Queues.Any())
            {
                _defaultDebugQueue = new Queue()
                {
                    CreatedOn = DateTime.Now,
                    RegistrationStart = DateTime.Now.AddHours(6),
                    LaboratoryWork = _defaultDebugLaboratoryWork,
                };

                await _dataBaseContext.Queues.AddAsync(_defaultDebugQueue);
            }
        }
    }
}
