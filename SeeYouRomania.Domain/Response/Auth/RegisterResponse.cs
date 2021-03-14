using Domain.Response.Abstract;

namespace Domain.Response.Auth
{
    public class RegisterResponse : FailableTaskResponse
    {
        public string CognitoUserEntityId { get; set; }
        public string FailureType { get; set; }
    }
}