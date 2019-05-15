using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Persistence
{
    public class HostOceanDbContext : IdentityDbContext<User>
    {
        public HostOceanDbContext(DbContextOptions<HostOceanDbContext> options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<LaboratoryWork> LaboratoryWorks { get; set; }
        public DbSet<LaboratoryWorkEvent> LaboratoryWorkEvents { get; set; }
        public DbSet<UserQueue> UserQueues { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HostOceanDbContext).Assembly);
        }
    }
}
