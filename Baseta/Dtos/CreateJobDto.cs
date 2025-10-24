using Baseta.Entities;

namespace Baseta.Dtos
{
    public class CreateJobDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; } = null!;
        public string? Features { get; set; }
        public List<int> JobTypeIds { get; set; }
        public int Salary { get; set; }
        public string? Requirements { get; set; }
        public int ExperenceRequirement { get; set; }
        public int GovernarateId {  get; set; }
        public List<int> CategoryIds {  get; set; }


    }
}
