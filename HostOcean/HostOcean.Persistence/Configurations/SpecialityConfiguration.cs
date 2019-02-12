using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Data.Configurations
{
    class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {

            builder
                .HasOne(f => f.Faculty)
                .WithMany(f => f.Specialities)
                .IsRequired();

            builder
               .HasMany(f => f.Groups)
               .WithOne(f => f.Speciality)
               .IsRequired();
        }
    }
}
