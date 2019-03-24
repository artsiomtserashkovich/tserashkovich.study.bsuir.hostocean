using System;
using System.Linq;
using System.Threading.Tasks;
using HostOcean.Application.Interfaces.Persistence;
using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Persistence.Repositories
{
    public class QueueRepository : Repository<Queue> , IQueueRepository
    {
        public QueueRepository(HostOceanDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Queue> GetQueueWithUserQueues(string id) =>
            await DbSet.Include(x => x.UserQueues)
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
