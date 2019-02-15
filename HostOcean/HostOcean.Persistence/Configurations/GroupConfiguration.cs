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
                .HasMany(f => f.Users)
                .WithOne(p => p.Group)
                .IsRequired();

            builder
                .HasMany(f => f.Labworks)
                .WithOne(p => p.Group);
        }
    }
}
