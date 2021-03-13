using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Request.UserOperations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyUser([FromBody] VerifyUserRequest request)
        {
            if (!IsAdmin())
            {
                return Unauthorized();
            }
            
            await userService.Verify(request);

            return NoContent();
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(string userId)
        {
            return Ok(userService.GetById(userId));
        }
    }
}