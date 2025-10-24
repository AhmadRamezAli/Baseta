namespace Baseta.Entities
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId {  get; set; }
        public Service service { get; set; }
        public int ServiceId { get; set; }
    }
}
