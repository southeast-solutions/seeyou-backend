namespace Domain
{
    public class PromoterEntity : UserEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CurrentJob { get; set; }
        public string DisponibilityDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ForeignLanguages { get; set; }
        public bool IsStudent { get; set; }
        public string SocialLinks { get; set; }
    }
}
