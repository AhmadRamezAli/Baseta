using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Entities.Type> builder)
        {
        builder.Property(e=>e.Name).HasMaxLength(50);
        builder.HasKey(e => e.Id);
            builder.HasMany(e=>e.JobTypes).WithOne(e=>e.Type).HasForeignKey(e=>e.TypeId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
