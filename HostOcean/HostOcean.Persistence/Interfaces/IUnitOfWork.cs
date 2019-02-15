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
        IRepository<University> Universities { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Speciality> Specialities { get; }
        IRepository<Group> Groups { get; }
        IRepository<Labwork> Labworks { get; }
        IRepository<Queue> Queues { get; }
        IRepository<Place> Places { get; }

        Task SaveAsync();
    }
}