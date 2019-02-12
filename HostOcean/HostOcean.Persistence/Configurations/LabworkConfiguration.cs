using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Data.Configurations
{
    class LabworkConfiguration : IEntityTypeConfiguration<Labwork>
    {
        public void Configure(EntityTypeBuilder<Labwork> builder)
        {
            builder
                .HasOne(f => f.Group)
                .WithMany(p => p.Labworks)
                .IsRequired();
        }
    }
}
