using Baseta.Entities;

namespace Baseta.Dtos
{
    public class ServiceDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CategoryDto> serviceCategories { get; set; } = [];
        public UserDto user { get; set; }

        public static ServiceDto Mapper(Service service)
        {
            return new ServiceDto
            {
                Description = service.Description,
                Title = service.Title,
                user = UserDto.Mapper(service.User),
                serviceCategories = service.serviceCategories.Select(e => CategoryDto.Mapper(e.Category)).ToList(),
            };

        }
    }
}
