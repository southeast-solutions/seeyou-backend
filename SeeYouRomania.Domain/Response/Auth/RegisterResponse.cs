using Domain.Enums;

namespace Domain.Response
{
    public class RegisterResponse : FailableTaskResponse
    {
        public string CognitoUserEntityId { get; set; }
        public RegisterFailureTypes FailureType { get; set; }
        public string Id { get; set; }
    }
}