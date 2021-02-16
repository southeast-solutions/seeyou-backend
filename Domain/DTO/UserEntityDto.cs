using Domain.Models;

namespace Domain.DTO
{
    public class UserEntityDto
    {
        public TourBusinessEntity TourBusinessEntity { get; set; }
        public TourOperatorEntity TourOperatorEntity { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CurrentJob { get; set; }
        public string DisponibilityDescription { get; set; }
        public string FirstName { get; set; }
        public string ForeignLanguages { get; set; }
        public string SocialLinks { get; set; }
        public bool IsStudent { get; set; }
        public string LastName { get; set; }
    }
}
