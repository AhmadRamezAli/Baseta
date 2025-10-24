using Baseta.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Baseta.Infrastructures
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Job>Jobs { get; set; }
        public DbSet<Location>Locations { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Entities.Type> Types {  get; set; }
        public DbSet<JobCategory> JobCategories {  get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Service> Services {  get; set; }
        public DbSet<ServiceCategory> ServicesCategories { get; set; }
        public DbSet<Governarate>Governarates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


    }
}
