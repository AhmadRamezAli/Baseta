namespace Baseta.Entities
{
    public class JobCategory
    {
        public int Id { get; set; }
        public int JobId {  get; set; }
        public Job Job { get; set; }
        public int CategoryId {  get; set; }
        public Category category { get; set; }
    }
}
