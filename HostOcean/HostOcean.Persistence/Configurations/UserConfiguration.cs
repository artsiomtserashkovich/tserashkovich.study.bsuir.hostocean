using HostOcean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HostOcean.Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(f => f.Group)
                .WithMany(p => p.Users)
                .IsRequired();

            builder
                .HasMany(f => f.UserQueues)
                .WithOne(p => p.User);

            builder
                .Property(x => x.UserSubGroup)
                .HasConversion(new EnumToNumberConverter<UserSubGroup, short>());
        }
    }
}
