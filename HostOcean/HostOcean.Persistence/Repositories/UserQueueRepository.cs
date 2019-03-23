using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Persistence.Repositories
{
    public class UserQueueRepository : Repository<UserQueue>, IUserQueueRepository
    {
        public UserQueueRepository(HostOceanDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<UserQueue> Query => 
            DbSet.Include(e => e.Queue).Include(e => e.User);

        public IEnumerable<TResult> GetPredicatedAsync<TResult>(
            Expression<Func<UserQueue, bool>> predicate,
            Expression<Func<UserQueue, TResult>> selector) =>
                DbSet.Where(predicate).Select(selector);
    }
}