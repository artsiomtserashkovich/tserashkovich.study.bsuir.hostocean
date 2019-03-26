using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{
    class LaboratoryWorkEventConfiguration : IEntityTypeConfiguration<LaboratoryWorkEvent>
    {
        public void Configure(EntityTypeBuilder<LaboratoryWorkEvent> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(f => f.LaboratoryWork)
                .WithMany(s => s.LaboratoryWorkEvents)
                .IsRequired();

            builder
               .HasOne(f => f.Queue)
               .WithOne(s => s.LaboratoryWorkEvent)
               .IsRequired();
        }
    }
}
