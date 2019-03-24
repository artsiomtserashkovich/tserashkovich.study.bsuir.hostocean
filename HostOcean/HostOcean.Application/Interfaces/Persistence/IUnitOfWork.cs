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
        ILaboratoryWorkRepository LaboratoryWorks { get; }
        IQueueRepository Queues { get; }
        IUserQueueRepository UserQueues { get; }

        Task SaveAsync();
    }
}