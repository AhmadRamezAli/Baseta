using Baseta.Entities;
using System.Runtime.CompilerServices;

namespace Baseta.Dtos
{
    public class JobDto
    {
     public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string LocationName { get; set; } = null!;
        public int LocationId { get; set; }
        public string? Features { get; set; }
        public List<TypeDto> Types { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public int Salary { get; set; }
        public string? Requirements { get; set; }
        public int ExperenceRequirement { get; set; }
        public GovernarateDto GovernarateDto { get; set; }

        public static JobDto Mapper(Job job)
        {

            return new JobDto
            {

                Id = job.Id,
                Name = job.Name,
                Description = job.Description,
                Salary = job.Salary,
                UserId = job.UserId,
                UserName = job.User.FirstName + " " + job.User.LastName,
                Requirements = job.Requirements,
                Features = job.Features,
                LocationId = job.LocationId,
                LocationName = job.Location.Name,
                ExperenceRequirement = job.ExperenceRequirement,
                Categories = job.JobCategories.Select(e => CategoryDto.Mapper(e.category)).ToList(),
                Types = job.JobTypes.Select(e => TypeDto.Mapper(e.Type)).ToList(),
                GovernarateDto= GovernarateDto.Mapper(job.Location.governarate),
            };
        }
    }
}
