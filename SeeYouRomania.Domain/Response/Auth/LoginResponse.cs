using Amazon.CognitoIdentityProvider.Model;
using Domain.Response.Abstract;

namespace Domain.Response.Auth
{
    public class LoginResponse : FailableTaskResponse
    {
        public string Token { get; set; }
        public string UserType { get; set; }
    }
}