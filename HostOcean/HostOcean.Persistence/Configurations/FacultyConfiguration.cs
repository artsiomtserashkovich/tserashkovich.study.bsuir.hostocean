using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostOcean.Persistence.Configurations
{
    class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder
                .HasOne(f => f.University)
                .WithMany(p => p.Faculties)
                .IsRequired();

            builder
                .HasMany(f => f.Specialities)
                .WithOne(p => p.Faculty);
        }
    }
}
