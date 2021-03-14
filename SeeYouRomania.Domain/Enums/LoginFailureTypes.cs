namespace Domain.Enums
{
    public static class LoginFailureTypes
    {
        public static string EmailNotFound => "EMAIL_NOT_FOUND";
        public static string InvalidCredentials => "INVALID_CREDENTIALS";
        public static string Other => "OTHER";
    }
}