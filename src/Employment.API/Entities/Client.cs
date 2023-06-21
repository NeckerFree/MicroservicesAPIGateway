using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Parser.Common.Entities;

namespace Employment.API.Entities
{
    public class Client : IEntity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
       
    }
}
