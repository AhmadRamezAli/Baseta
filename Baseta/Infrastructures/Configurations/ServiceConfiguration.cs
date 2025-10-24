using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(e=>e.User).WithMany(e=>e.Services).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(e => e.serviceCategories).WithOne(e=>e.service).HasForeignKey(e => e.ServiceId).OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
