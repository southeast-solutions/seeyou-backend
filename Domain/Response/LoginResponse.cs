using Domain.Enums;

namespace Domain.Response
{
    public class LoginResponse : FailableTaskResponse
    {
        public string Token { get; set; }
        public LoginFailureTypes FailureType { get; set; }
    }
}