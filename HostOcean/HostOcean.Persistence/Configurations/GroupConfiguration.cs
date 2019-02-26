using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(f => f.Users)
                .WithOne(p => p.Group);

            builder
                .HasMany(f => f.LaboratoryWorks)
                .WithOne(p => p.Group);
        }
    }
}
