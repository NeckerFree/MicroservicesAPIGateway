namespace Gateway.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        //public string? Phone { get; set; }
        //public DateTimeOffset? Created { get; set; }
        public List<JobPosition> Jobs { get; set; }=new List<JobPosition>();
    }
}
