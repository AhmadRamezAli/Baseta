using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baseta.Infrastructures.Configurations
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(e=>e.Job).WithMany(e=>e.JobTypes).HasForeignKey(x => x.JobId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e=>e.Type).WithMany(e=>e.JobTypes).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
