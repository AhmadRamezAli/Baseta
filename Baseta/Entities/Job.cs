using Baseta.Entities.Abstractions;

namespace Baseta.Entities
{
    public class Job:BaseEntity
    {

        public string Name {  get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public int UserId {  get; set; }
        public Location Location { get; set; } = null!;
        public int LocationId {  get; set; }
        public string? Features {  get; set; }
        public List<JobType> JobTypes { get; set; }
        public List<JobCategory>? JobCategories { get; set; }
        public int Salary {  get; set; }
        public string? Requirements {  get; set; }
        public int ExperenceRequirement {  get; set; }
        
    }
}
