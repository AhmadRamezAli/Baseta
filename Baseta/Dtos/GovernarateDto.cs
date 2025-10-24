using Baseta.Entities;

namespace Baseta.Dtos
{
    public class GovernarateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static GovernarateDto Mapper(Governarate governarate)
        {

            return new GovernarateDto
            {
                Id = governarate.Id,
                Name = governarate.Name,

            };
        }
    }
}
