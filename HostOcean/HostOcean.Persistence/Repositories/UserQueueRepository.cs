using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Remotion.Linq.Clauses;

namespace HostOcean.Persistence.Repositories
{
    public class UserQueueRepository: Repository<UserQueue>, IUserQueueRepository
    {
        public UserQueueRepository(HostOceanDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> PredicateCountAsync(Expression<Func<UserQueue, bool>> predicate) =>
            await DbSet.FromSql(SelectClause );

        protected override IQueryable<UserQueue> Query => DbSet.Include(e => e.Queue).Include(e => e.User);
    }
}
