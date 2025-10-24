using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Service:BaseEntity,ISoftDeleted
    {
        public bool IsDeleted { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public List<ServiceCategory> serviceCategories { get; set; } = [];
        public int UserId {  get; set; }
        public User User { get; set; }
    }
}
