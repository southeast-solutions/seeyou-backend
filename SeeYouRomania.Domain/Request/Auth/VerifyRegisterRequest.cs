namespace Domain.Request.Auth
{
    public class VerifyRegisterRequest
    {
        public string Code { get; set; }
        public string Email { get; set; }
    }
}