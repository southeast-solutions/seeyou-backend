namespace Domain.Request.Auth
{
    public class ConfirmResetPasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string Code { get; set; }
    }
}