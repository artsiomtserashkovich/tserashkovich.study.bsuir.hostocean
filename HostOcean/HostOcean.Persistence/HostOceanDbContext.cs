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
        public DbSet<Labwork> Labworks { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HostOceanDbContext).Assembly);
        }
    }
}
