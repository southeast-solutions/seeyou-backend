namespace Domain.Enums
{
    public static class RegisterFailureTypes
    {
        public static string InvalidPassword => "INVALID_PASSWORD";
        public static string EmailAddressTaken => "EMAIL_ADDRESS_TAKEN";
        public static string Other => "OTHER";
    }
}