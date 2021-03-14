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

        [HttpGet("userData")]
        public async Task<IActionResult> GetUserData()
        {
            var user = await userService.GetById(GetId());

            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            var user = await userService.GetById(userId);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            await userService.Update(GetId(), request);

            return Ok();
        }
    }
}