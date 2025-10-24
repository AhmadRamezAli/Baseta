using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(e=>e.JobCategories).WithOne(e=>e.Job).HasForeignKey(e=>e.JobId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(e=>e.JobTypes).WithOne(e=>e.Job).HasForeignKey(e=>e.JobId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e=>e.Location).WithMany(e=>e.Jobs).HasForeignKey(e => e.LocationId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e => e.User).WithMany(e=>e.jobs).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
