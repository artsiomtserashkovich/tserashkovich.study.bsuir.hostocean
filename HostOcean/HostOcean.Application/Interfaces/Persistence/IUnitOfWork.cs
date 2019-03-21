using System;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HostOcean.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        IRepository<Group> Groups { get; }
        IRepository<LaboratoryWork> LaboratoryWorks { get; }
        IRepository<Queue> Queues { get; }
        IUserQueueRepository UserQueues { get; }

        Task SaveAsync();
    }
}