namespace Domain.Request
{
    public class VerifyRegisterRequest
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}