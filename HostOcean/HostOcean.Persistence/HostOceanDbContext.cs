using HostOcean.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HostOcean.Data
{
    public class HostOceanDbContext : IdentityDbContext<User>
    {
        public HostOceanDbContext(DbContextOptions<HostOceanDbContext> options) : base(options)
        {
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Labwork> Labworks { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HostOceanDbContext).Assembly);
        }
    }
}
