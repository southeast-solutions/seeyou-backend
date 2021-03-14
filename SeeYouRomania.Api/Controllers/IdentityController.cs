using System;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider.Model;
using Domain.Contracts;
using Domain.DTO;
using Domain.Enums;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : BaseController
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public IdentityController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserEntityDto userEntity)
        {
            var registerResponse = new RegisterResponse();

            try
            {
                var registerRequest = new RegisterRequest()
                {
                    Email = userEntity.Email,
                    Password = userEntity.Password,
                    UserType = userEntity.UserType
                };

                registerResponse = await authService.Register(registerRequest);

                await userService.Add(userEntity, registerResponse.CognitoUserEntityId);
            }
            catch (InvalidPasswordException)
            {
                registerResponse.Success = false;
                registerResponse.FailureType = RegisterFailureTypes.InvalidPassword;
            }
            catch (UsernameExistsException)
            {
                registerResponse.Success = false;
                registerResponse.FailureType = RegisterFailureTypes.EmailAlreadyTaken;
            }
            catch (Exception)
            {
                registerResponse.Success = false;
                registerResponse.FailureType = RegisterFailureTypes.Other;
            }
            
            if (!registerResponse.Success)
            {
                return Ok(registerResponse);
            }

            return Created(nameof(Register), registerResponse);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse loginResponse = await authService.Login(loginRequest);

            return Ok(loginResponse);
        }
        
        [HttpPost("verifyRegister")]
        public async Task<IActionResult> VerifyRegister([FromBody] VerifyRegisterRequest request)
        {
            VerifyRegisterResponse response = await authService.VerifyRegister(request);
            
            return Ok(response);
        }
        
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await authService.ResetPassword(request);
            return Ok();
        }
        
        [HttpPost("confirmResetPassword")]
        public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordRequest request)
        {
            var response = await authService.ConfirmResetPassword(request);
            return Ok(response);
        }
    }
}
