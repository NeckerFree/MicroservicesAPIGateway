using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Parser.Common.Entities;

namespace Consumer.API.Entities
{
    public class Client : IEntity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTimeOffset? Created { get; set; }
    }
}
