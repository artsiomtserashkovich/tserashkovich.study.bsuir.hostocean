using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Data.Configurations
{
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasOne(f => f.Speciality)
                .WithMany(p => p.Groups)
                .IsRequired();

            builder
                .HasMany(f => f.Labworks)
                .WithOne(p => p.Group);
        }
    }
}
