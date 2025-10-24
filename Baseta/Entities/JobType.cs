namespace Baseta.Entities
{
    public class JobType
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int TypeId {  get; set; }
        public Type Type { get; set; }
    }
}
