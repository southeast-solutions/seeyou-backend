using Domain.Attributes;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    [BsonCollection("users")]
    public abstract class UserEntity : Document
    {
        [BsonRepresentation(BsonType.String)]
        public UserTypes UserType { get; set; }
        
        public bool Verified { get; set; }
    }
}
