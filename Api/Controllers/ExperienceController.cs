using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Request.Experiences;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        [HttpPost("getExperiences")]
        public IActionResult GetExperiences([FromBody] ExperiencesRequest experiencesRequest)
        {
            var experiences = experienceService.GetAllAsync(experiencesRequest);
            return Ok(experiences);
        }

        [HttpPost("addExperience")]
        public async Task<IActionResult> AddExperience([FromBody] AddExperienceRequest addExperienceRequest)
        {
            await experienceService.Add(addExperienceRequest);

            return Created(nameof(AddExperience), addExperienceRequest);
        }

        [HttpPost("updateExperience")]
        public async Task<IActionResult> UpdateExperience([FromBody] UpdateExperienceRequest updateExperienceRequest)
        {
            await experienceService.Update(updateExperienceRequest);

            return Ok(updateExperienceRequest);
        }

        [HttpPost("deleteExperience")]
        public async Task<IActionResult> DeleteExperience([FromBody] DeleteExperienceRequest deleteExperienceRequest)
        {
            await experienceService.Delete(deleteExperienceRequest);

            return Ok(deleteExperienceRequest);
        }
    }
}
