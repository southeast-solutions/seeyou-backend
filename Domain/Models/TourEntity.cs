using Domain.Attributes;

namespace Domain
{
    [BsonCollection("users")]
    public class TourEntity : UserEntity
    {
        public TourBusinessData TourBusinessData;
        public TourOperatorData TourOperatorData;
    }

    public class TourBusinessData
    {
        public string Adress { get; set; }
        public string BusinessName { get; set; }
        public string Cui { get; set; }
        public string Website { get; set; }
        public string SocialLinks { get; set; }
    }

    public class TourOperatorData
    {
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialLinks { get; set; }
        public string ForeignLanguages { get; set; }
    }
}
