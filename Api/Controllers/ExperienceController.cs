using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.DTO;
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

        [HttpGet]
        public IActionResult Get()
        {
            var experiences = experienceService.GetAll();
            return Ok(experiences);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExperienceEntityDto experienceEntity)
        {
            await experienceService.Add(experienceEntity);

            return Created(nameof(Post), experienceEntity);
        }
    }
}
