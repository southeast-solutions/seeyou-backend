using System.Collections.Generic;

namespace Domain.Response.Experiences
{
    public class GetExperiencesByLocationResponse
    {
        public IEnumerable<ExperienceEntity> Experiences { get; set; }
    }
}