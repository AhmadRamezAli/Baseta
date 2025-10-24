using Baseta.Entities;

namespace Baseta.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    public static CategoryDto Mapper(Category category)
        {

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
    
}
