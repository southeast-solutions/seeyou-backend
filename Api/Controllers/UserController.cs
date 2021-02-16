using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEntityDto userEntity)
        {
            await userService.Add(userEntity);

            return Created(nameof(Post), userEntity);
        }
    }
}
