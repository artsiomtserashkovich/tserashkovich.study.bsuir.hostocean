using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistence;

namespace HostOcean.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(HostOceanDbContext applicationDataBaseContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IRepository<Group> groups,
            IRepository<LaboratoryWork> laboratoryWorks,
            IRepository<Queue> queues,
            IRepository<UserQueue> userQueues
        )
        {
            ApplicationDataBaseContext = applicationDataBaseContext;
            UserManager = userManager;
            SignInManager = signInManager;

            Groups = groups;
            LaboratoryWorks = laboratoryWorks;
            Queues = queues;
            UserQueues = userQueues;
        }

        public HostOceanDbContext ApplicationDataBaseContext { get; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }
        public IRepository<Group> Groups { get; private set; }
        public IRepository<LaboratoryWork> LaboratoryWorks { get; private set; }
        public IRepository<Queue> Queues { get; private set; }
        public IRepository<UserQueue> UserQueues { get; private set; }

        public async Task SaveAsync() => await ApplicationDataBaseContext.SaveChangesAsync();

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ApplicationDataBaseContext.Dispose();
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