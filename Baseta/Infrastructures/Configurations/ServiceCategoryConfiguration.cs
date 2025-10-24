using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(e=>e.service).WithMany(e=>e.serviceCategories).HasForeignKey(e=>e.ServiceId).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(e => e.Category).WithMany(e => e.ServiceCategories).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
