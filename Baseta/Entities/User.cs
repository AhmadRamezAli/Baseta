using Baseta.Entities.Abstractions;
using System.Reflection.Metadata;

namespace Baseta.Entities
{
    public class User : BaseEntity, ISoftDeleted
    {
        public bool IsDeleted { get; set;}
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password {  get; set; } = null!;
        public List<ContactInfo> ContactInfos { get; set; } = [];
        public List<Job> jobs { get; set; } = [];
        public List<Service>Services { get; set; } = [];
    }
}
