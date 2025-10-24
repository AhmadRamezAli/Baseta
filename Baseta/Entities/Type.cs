using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Type:BaseEntity
    {
        public string Name { get; set; }
        public List<JobType>JobTypes { get; set; }
    }
}
