using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Persistence
{
    public class HostOceanDBContext : IdentityDbContext<User>
    {
        public HostOceanDBContext(DbContextOptions<HostOceanDBContext> options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<LaboratoryWork> LaboratoryWorks { get; set; }
        public DbSet<UserQueue> UserQueues { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HostOceanDBContext).Assembly);
        }
    }
}
