using Domain.Attributes;

namespace Domain
{
    [BsonCollection("users")]
    public class ContentCreatorEntity : UserEntity
    {
        public string City { get; set; }
        public string DisponibilityDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ForeignLanguages { get; set; }
        public string SocialLinks { get; set; }
    }
}
