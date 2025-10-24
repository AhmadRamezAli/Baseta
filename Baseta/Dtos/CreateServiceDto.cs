namespace Baseta.Dtos
{
    public class CreateServiceDto
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
