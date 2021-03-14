using Domain.Attributes;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonCollection("users")]
    [BsonKnownTypes(typeof(ConciergeEntity), typeof(ContentCreatorEntity), typeof(PromoterEntity), typeof(TourEntity))]
    public abstract class UserEntity : Document
    {
        public UserTypes UserType { get; set; }
        public bool Verified { get; set; }
    }
}
