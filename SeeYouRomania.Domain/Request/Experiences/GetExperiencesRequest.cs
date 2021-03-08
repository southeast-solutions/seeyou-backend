using Domain.Models;

namespace Domain.Request.Experiences
{
    public class GetExperiencesRequest
    {
        public string Country { get; set; }
        public PhysicalLocationEntity Location { get; set; }
    }
}
