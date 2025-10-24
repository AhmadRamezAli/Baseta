using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class GovernarateConfiguration : IEntityTypeConfiguration<Governarate>
    {
        public void Configure(EntityTypeBuilder<Governarate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(e=>e.Locations).WithOne(e=>e.governarate).HasForeignKey(e=>e.GovernarateId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
