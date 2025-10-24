using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Category:BaseEntity
    {
        public string Name {  get; set; }
        public string? Description { get; set; }
        public List<JobCategory> JobCategories { get; set; } = [];
        public List<ServiceCategory> ServiceCategories { get; set; } = [];
    }
}
