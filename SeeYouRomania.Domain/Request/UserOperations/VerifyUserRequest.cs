namespace Domain.Request.UserOperations
{
    public class VerifyUserRequest
    {
        public string Id { get; set; }
        public bool VerifiedValue { get; set; }
    }
}