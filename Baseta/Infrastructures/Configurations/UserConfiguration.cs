using Baseta.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Baseta.Infrastructures.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(u => u.Id);

                builder.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);
            builder.HasMany(e=>e.jobs).WithOne(e=>e.User).HasForeignKey(u => u.UserId);
            builder.HasMany(e=>e.ContactInfos).WithOne(e=>e.User).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(e=>e.Services).WithOne(e=>e.User).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.ClientCascade);
        }
        }
}
