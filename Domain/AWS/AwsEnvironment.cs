namespace Domain.AWS
{
    public class AwsEnvironment
    {
        public string Region { get; set; }
        public string UserPoolId { get; set; }
        public string AppClientId { get; set; }
        public string IdentityPoolId { get; set; }
        public bool Prod { get; set; }
    }
}