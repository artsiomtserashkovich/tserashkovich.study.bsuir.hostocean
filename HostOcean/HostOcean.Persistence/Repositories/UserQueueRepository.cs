using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HostOcean.Persistence.Repositories
{
    public class UserQueueRepository : Repository<UserQueue>, IUserQueueRepository
    {
        public UserQueueRepository(HostOceanDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<UserQueue> Query => DbSet.Include(e => e.Queue).Include(e => e.User);
    }
}
