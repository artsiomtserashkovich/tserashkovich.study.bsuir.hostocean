using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HostOcean.Persistence.Configurations
{
    class LaboratoryWorkConfiguration : IEntityTypeConfiguration<LaboratoryWork>
    {
        public void Configure(EntityTypeBuilder<LaboratoryWork> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(f => f.Group)
                .WithMany(p => p.LaboratoryWorks)
                .HasForeignKey(x => x.GroupId)
                .IsRequired();

            builder
                .HasOne(f => f.Queue)
                .WithOne(p => p.LaboratoryWork)
                .HasForeignKey<Queue>(x => x.LaboratoryWorkId)
                .IsRequired();

            builder
                .Property(x => x.SubGroup)
                .HasConversion(new EnumToNumberConverter<SubGroup, short>());
        }
    }
}
