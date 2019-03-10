using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace HostOcean.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        HostOceanDbContext ApplicationDataBaseContext { get; }
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        IRepository<Group> Groups { get; }
        IRepository<LaboratoryWork> LaboratoryWorks { get; }
        IRepository<Queue> Queues { get; }
        IRepository<UserQueue> UserQueues { get; }

        Task SaveAsync();
    }
}