namespace Baseta.Dtos
{
    public class TypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static TypeDto Mapper(Entities.Type type)
        {
            return new TypeDto
            {
                Id = type.Id,
                Name = type.Name,
            };
        }
    }
}
