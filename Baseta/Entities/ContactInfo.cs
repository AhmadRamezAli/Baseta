using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class ContactInfo:BaseEntity
    {
        public int  UserId { get; set; }
        public User User { get; set; }
        public string Type {  get; set; }
        public string Value {  get; set; }
    }
}
