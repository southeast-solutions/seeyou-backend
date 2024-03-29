﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Domain.AWS;
using Domain.Contracts;
using Domain.Enums;
using Domain.Request.Auth;
using Domain.Response.Auth;
using Microsoft.Extensions.Logging;

namespace Business.Services
{
    public class CognitoAuthService : IAuthService
    {
        private readonly AmazonCognitoIdentityProviderClient client;
        private readonly AwsEnvironment awsEnvironment;
        private readonly ILogger logger;
        
        public CognitoAuthService(AwsEnvironment awsEnvironment, ILogger<CognitoAuthService> logger)
        {
            this.client = new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName(awsEnvironment.Region));
            this.awsEnvironment = awsEnvironment;
            this.logger = logger;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var registerRequest = new SignUpRequest()
            {
                ClientId = awsEnvironment.AppClientId,
                Username = request.Email,
                Password = request.Password
            };
            
            var emailAttribute = new AttributeType
            {
                Name = ClaimNames.Email,
                Value = request.Email
            };

            var userType = new AttributeType()
            {
                Name = ClaimNames.UserType,
                Value = request.UserType
            };

            var userId = new AttributeType()
            {
                Name = ClaimNames.UserId,
                Value = request.UserId
            };
            
            registerRequest.UserAttributes.Add(emailAttribute);
            registerRequest.UserAttributes.Add(userType);
            registerRequest.UserAttributes.Add(userId);
            
            RegisterResponse registerResponse = new RegisterResponse()
            {
                Success = false
            };

            try
            {
                await client.SignUpAsync(registerRequest);
                registerResponse.Success = true;
            }
            catch (UsernameExistsException e)
            {
                logger.LogError(e.StackTrace);
                registerResponse.FailureType = RegisterFailureTypes.EmailAddressTaken;
            }
            catch (InvalidPasswordException e)
            {
                logger.LogError(e.Message);
                registerResponse.FailureType = RegisterFailureTypes.InvalidPassword;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                registerResponse.FailureType = RegisterFailureTypes.Other;
            }

            return registerResponse;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            CognitoUserPool userPool =
                new CognitoUserPool(awsEnvironment.UserPoolId, awsEnvironment.AppClientId, client);
            CognitoUser user = new CognitoUser(request.Email, awsEnvironment.AppClientId, userPool, client);
            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = request.Password,
            };

            LoginResponse loginResponse = new LoginResponse()
            {
                Success = false
            };

            try
            {
                AuthFlowResponse authResponse = await user.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);
                loginResponse.Token = authResponse.AuthenticationResult.IdToken;
                loginResponse.Success = true;

                GetUserRequest getUserRequest = new GetUserRequest()
                {
                    AccessToken = authResponse.AuthenticationResult.AccessToken
                };
                var getUserResponse = await client.GetUserAsync(getUserRequest);
                loginResponse.UserType =
                    getUserResponse.UserAttributes.First(a => a.Name.Equals(ClaimNames.UserType)).Value;
            }
            catch (UserNotFoundException)
            {
                loginResponse.FailureType = LoginFailureTypes.EmailNotFound;
            }
            catch (NotAuthorizedException)
            {
                loginResponse.FailureType = LoginFailureTypes.InvalidCredentials;
            }
            catch (Exception)
            {
                loginResponse.FailureType = LoginFailureTypes.Other;
            }

            return loginResponse;
        }

        public async Task<VerifyRegisterResponse> VerifyRegister(VerifyRegisterRequest request)
        {
            var verifyRequest = new ConfirmSignUpRequest()
            {
                ClientId = awsEnvironment.AppClientId,
                ConfirmationCode = request.Code,
                Username = request.Email
            };

            bool success = true;
            
            try
            {
                await client.ConfirmSignUpAsync(verifyRequest);
            }
            catch (Exception)
            {
                success = false;
            }

            return new VerifyRegisterResponse()
            {
                Success = success,
            };
        }

        public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request)
        {
            var forgotPassReq = new ForgotPasswordRequest()
            {
                Username = request.Email,
                ClientId = awsEnvironment.AppClientId
            };

            ResetPasswordResponse resetPasswordResponse = new ResetPasswordResponse()
            {
                Success = true
            };

            try
            {
                await client.ForgotPasswordAsync(forgotPassReq);
            }
            catch (Exception)
            {
                resetPasswordResponse.Success = false;
            }

            return resetPasswordResponse;
        }

        public async Task<ConfirmResetPasswordResponse> ConfirmResetPassword(ConfirmResetPasswordRequest request)
        {
            var confirmForgotPasswordRequest = new ConfirmForgotPasswordRequest()
            {
                Username = request.Email,
                Password = request.NewPassword,
                ConfirmationCode = request.Code,
                ClientId = awsEnvironment.AppClientId
            };

            bool success = true;

            try
            {
                await client.ConfirmForgotPasswordAsync(confirmForgotPasswordRequest);
            }
            catch (Exception)
            {
                success = false;
            }

            return new ConfirmResetPasswordResponse()
            {
                Success = success
            };
        }
    }
}