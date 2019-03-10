using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{
    class UserQueueConfiguration : IEntityTypeConfiguration<UserQueue>
    {
        public void Configure(EntityTypeBuilder<UserQueue> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasIndex(f => new { f.QueueId, f.Order })
                .IsUnique();

            builder
                .HasIndex(f => new { f.QueueId, f.UserId })
                .IsUnique();

            builder
                .HasOne(f => f.Queue)
                .WithMany(p => p.UserQueues)
                .HasForeignKey(x => x.QueueId)
                .IsRequired();

            builder
                .HasOne(f => f.User)
                .WithMany(p => p.UserQueues)
                .HasForeignKey(x => x.UserId);
        }
    }
}
