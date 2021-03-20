using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain
{
    public abstract class Document
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}