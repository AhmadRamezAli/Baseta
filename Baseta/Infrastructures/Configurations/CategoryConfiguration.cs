using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(e=>e.JobCategories).WithOne(e=>e.category).HasForeignKey(e=>e.CategoryId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
