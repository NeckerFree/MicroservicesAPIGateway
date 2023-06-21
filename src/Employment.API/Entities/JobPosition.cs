using Parser.Common.Entities;

namespace Employment.API.Entities
{
    public class JobPosition : IEntity
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Requisites { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
