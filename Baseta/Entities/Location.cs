using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Location:BaseEntity,ISoftDeleted
    {
        public bool IsDeleted {  get; set; }
        public string Name {  get; set; }
        public List<Job>Jobs { get; set; }
        public int GovernarateId {  get; set; }
        public Governarate governarate { get; set; } = null!;
    }
}
