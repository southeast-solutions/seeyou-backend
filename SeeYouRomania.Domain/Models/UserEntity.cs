using Domain.Attributes;
using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonCollection("users")]
    [BsonKnownTypes(typeof(ConciergeEntity), typeof(ContentCreatorEntity), typeof(PromoterEntity), typeof(TourEntity), typeof(AdminEntity))]
    public abstract class UserEntity : Document
    {
        public string UserType { get; set; }
        public bool Verified { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
