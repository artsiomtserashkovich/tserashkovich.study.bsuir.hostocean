using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{

    public class QueueConfiguration : IEntityTypeConfiguration<Queue>
    {
        public void Configure(EntityTypeBuilder<Queue> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(f => f.LaboratoryWork)
                .WithOne(p => p.Queue);

            builder
                .HasMany(f => f.UserQueues)
                .WithOne(p => p.Queue);
        }
    }
}