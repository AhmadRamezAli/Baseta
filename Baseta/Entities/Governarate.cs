using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Governarate:BaseEntity
    {
        public string Name {  get; set; }
        public List<Location> Locations { get; set; } = [];
    }
}
