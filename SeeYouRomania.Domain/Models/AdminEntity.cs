using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonDiscriminator("Admin")]
    public class AdminEntity : ConciergeEntity
    {
    }
}
