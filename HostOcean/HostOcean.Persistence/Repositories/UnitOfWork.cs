using HostOcean.Domain.Entities;
using HostOcean.Persistence.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HostOcean.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(HostOceanDbContext applicationDataBaseContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IRepository<Group> groups,
            IRepository<Labwork> labworks,
            IRepository<Queue> queues,
            IRepository<Place> places
        )
        {
            ApplicationDataBaseContext = applicationDataBaseContext;
            UserManager = userManager;
            SignInManager = signInManager;

            Groups = groups;
            Labworks = labworks;
            Queues = queues;
            Places = places;
        }

        public HostOceanDbContext ApplicationDataBaseContext { get; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }
        public IRepository<Group> Groups { get; private set; }
        public IRepository<Labwork> Labworks { get; private set; }
        public IRepository<Queue> Queues { get; private set; }
        public IRepository<Place> Places { get; private set; }

        public async Task SaveAsync() => await ApplicationDataBaseContext.SaveChangesAsync();

        private bool _disposed = false;

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