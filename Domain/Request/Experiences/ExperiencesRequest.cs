using Domain.Models;

namespace Domain.Request.Experiences
{
    public class ExperiencesRequest
    {
        public string Country { get; set; }
        public PhysicalLocationEntity Location { get; set; }
    }
}
