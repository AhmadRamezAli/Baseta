using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(e=>e.category).WithMany(e=>e.JobCategories).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e=>e.Job).WithMany(e=>e.JobCategories).HasForeignKey(e=>e.JobId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
