using System.Threading.Tasks;
using Domain.Contracts;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestEntityDto testEntity)
        {
            await testService.Add(testEntity);

            return Created(nameof(Post), testEntity);
        }
    }
}