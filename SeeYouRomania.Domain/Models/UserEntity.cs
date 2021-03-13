using Domain.Attributes;
using Domain.Enums;

namespace Domain
{
    [BsonCollection("users")]
    public class UserEntity : Document
    {
        public UserTypes UserType { get; set; }
        
        public bool Verified { get; set; }
    }
}
