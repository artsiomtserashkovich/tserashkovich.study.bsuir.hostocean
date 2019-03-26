using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistence;

namespace HostOcean.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(HostOceanDbContext applicationDbContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IRepository<Group> groups,
            IRepository<LaboratoryWorkEvent> events,
            ILaboratoryWorkRepository laboratoryWorks,
            IQueueRepository queues,
            IUserQueueRepository userQueues
        )
        {
            ApplicationDbContext = applicationDbContext;
            UserManager = userManager;
            SignInManager = signInManager;

            Groups = groups;
            Events = events;
            LaboratoryWorks = laboratoryWorks;
            Queues = queues;
            UserQueues = userQueues;
        }

        public HostOceanDbContext ApplicationDbContext { get; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }
        public IRepository<Group> Groups { get; private set; }
        public IRepository<LaboratoryWorkEvent> Events { get; private set; }
        public ILaboratoryWorkRepository LaboratoryWorks { get; private set; }
        public IQueueRepository Queues { get; private set; }
        public IUserQueueRepository UserQueues { get; private set; }

        public async Task SaveAsync() => await ApplicationDbContext.SaveChangesAsync();

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ApplicationDbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}