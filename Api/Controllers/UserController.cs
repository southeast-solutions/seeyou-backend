using System;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.DTO;
using Domain.Request;
using Domain.Request.Auth;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        private readonly IAuthService authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserEntityDto userEntity)
        {               
            var registerRequest = new RegisterRequest()
            {
                Email = userEntity.Email,
                Password = userEntity.Password
            };
            
            var registerResponse = await authService.Register(registerRequest);
            if (!registerResponse.Success)
            {
                return Ok(registerResponse);
            }

            try
            {
                await userService.Add(userEntity);
            }
            catch (Exception)
            {
                var deleteRequest = new DeleteAuthUserRequest()
                {
                    Id = registerResponse.Id
                };

                await authService.DeleteUser(deleteRequest);

                return StatusCode(500);
            }

            return Created(nameof(Register), userEntity);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse loginResponse = await authService.Login(loginRequest);

            return Ok(loginResponse);
        }
        
        [HttpPost("verifyRegister")]
        public async Task<IActionResult> Login([FromBody] VerifyRegisterRequest request)
        {
            VerifyRegisterResponse response = await authService.VerifyRegister(request);
            
            return Ok(response);
        }
        
        [HttpPost("resetPassword")]
        public async Task<IActionResult> Login([FromBody] ResetPasswordRequest request)
        {
            await authService.ResetPassword(request);
            return Ok();
        }
        
        [HttpPost("confirmResetPassword")]
        public async Task<IActionResult> Login([FromBody] ConfirmResetPasswordRequest request)
        {
            var response = await authService.ConfirmResetPassword(request);
            return Ok(response);
        }
    }
}
