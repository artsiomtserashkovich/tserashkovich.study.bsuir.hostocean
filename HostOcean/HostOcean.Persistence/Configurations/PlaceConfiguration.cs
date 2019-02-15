using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{
    class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder
                .HasKey(f => new { f.Id });

            builder
                .HasIndex(f => new { f.QueueId, f.Order })
                .IsUnique();

            builder
                .HasIndex(f => new { f.QueueId, f.UserId })
                .IsUnique();

            builder
                .HasOne(f => f.Queue)
                .WithMany(p => p.Places)
                .HasForeignKey(_ => _.QueueId)
                .IsRequired();

            builder
                .HasOne(f => f.User)
                .WithMany(p => p.Places)
                .HasForeignKey(_ => _.UserId);
        }
    }
}
