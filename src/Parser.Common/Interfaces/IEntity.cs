using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Parser.Common.Entities
{
    public interface IEntity
    {
        [BsonRepresentation(BsonType.String)]
        Guid Id { get; set; }
    }
}