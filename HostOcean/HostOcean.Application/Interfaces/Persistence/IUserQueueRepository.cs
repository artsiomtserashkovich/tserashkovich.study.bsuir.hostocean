using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HostOcean.Domain.Entities;

namespace HostOcean.Application.Interfaces.Persistence
{
    public interface IUserQueueRepository: IRepository<UserQueue>
    {
        Task<int> PredicateCountAsync(Expression<Func<UserQueue, bool>> predicate);
    }
}
