using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Request.Experiences;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ExperienceController : BaseController
    {
        private readonly IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        [HttpPost("getExperiences")]
        public async Task<IActionResult> GetExperiences([FromBody] GetExperiencesRequest getExperiencesRequest)
        {
            var experiences = await experienceService.GetAllAsync(getExperiencesRequest);
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
