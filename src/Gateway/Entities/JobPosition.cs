using System.Text.Json.Serialization;

namespace Gateway.Entities
{
    public class JobPosition 
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid ClientId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Requisites { get; set; }
        //public DateTimeOffset CreationDate { get; set; }
    }
}
