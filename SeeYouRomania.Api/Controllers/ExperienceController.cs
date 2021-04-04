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

        [HttpGet("myExperiences")]
        public async Task<IActionResult> GetMyExperiences()
        {
            var req = new GetExperiencesByUserIdRequest()
            {
                UserId = GetId()
            };

            var res = await experienceService.GetByUserId(req);

            return Ok(res);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetExperiencesById(string userId)
        {
            var req = new GetExperiencesByUserIdRequest()
            {
                UserId = userId
            };

            var res = await experienceService.GetByUserId(req);
            return Ok(res);
        }

        [HttpPost("getByLocation")]
        public async Task<IActionResult> GetExperiences([FromBody] GetExperiencesByLocationRequest getExperiencesByLocationRequest)
        {
            var experiences = await experienceService.GetByLocation(getExperiencesByLocationRequest);
            return Ok(experiences);
        }

        [HttpPost("addExperience")]
        public async Task<IActionResult> AddExperience([FromBody] AddExperienceRequest addExperienceRequest)
        {
            var id = GetId();
            await experienceService.Add(addExperienceRequest, id);

            return Created(nameof(AddExperience), addExperienceRequest);
        }

        [HttpPost("updateExperience")]
        public async Task<IActionResult> UpdateExperience([FromBody] UpdateExperienceRequest updateExperienceRequest)
        {
            var userId = GetId();
            await experienceService.Update(updateExperienceRequest, userId);

            return Ok(updateExperienceRequest);
        }

        [HttpPost("deleteExperience")]
        public async Task<IActionResult> DeleteExperience([FromBody] DeleteExperienceRequest deleteExperienceRequest)
        {
            var userId = GetId();
            await experienceService.Delete(deleteExperienceRequest, userId);

            return Ok(deleteExperienceRequest);
        }
    }
}
