using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Data.Configurations
{

    public class QueueConfiguration : IEntityTypeConfiguration<Queue>
    {
        public void Configure(EntityTypeBuilder<Queue> builder)
        {
            builder
                .HasOne(f => f.Labwork)
                .WithMany()
                .IsRequired();

            builder
                .HasIndex(f => f.LabworkId)
                .IsUnique();

            builder
                .HasMany(f => f.Places)
                .WithOne(p => p.Queue);
        }
    }
}