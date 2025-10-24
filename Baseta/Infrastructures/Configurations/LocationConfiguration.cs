using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e=>e.Name).HasMaxLength(256);
            builder.HasMany(e=>e.Jobs).WithOne(e=>e.Location).HasForeignKey(e=>e.LocationId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e=>e.governarate).WithMany(e=>e.Locations).HasForeignKey(e=>e.GovernarateId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
