using Domain.Enums;

namespace Domain.Response
{
    public class RegisterResponse : FailableTaskResponse
    {
        public RegisterFailureTypes FailureType { get; set; }
        public string Id { get; set; }
    }
}