using System.Collections.Generic;

namespace Domain.Response.Experiences
{
    public class GetExperiencesByUserIdResponse
    {
        public IEnumerable<ExperienceEntity> Experiences { get; set; }
    }
}