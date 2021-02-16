using Domain.Attributes;

namespace Domain
{
    [BsonCollection("users")]
    public abstract class UserEntity : Document
    {
        public string UserType { get; set; }
    }
}
