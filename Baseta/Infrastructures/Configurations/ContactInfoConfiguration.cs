using Baseta.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Baseta.Infrastructures.Configurations
{
    public class ContactInfoConfiguration
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(e=>e.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u =>u.Type)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.User).WithMany(e => e.ContactInfos).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
