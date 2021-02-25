namespace Domain.AWS
{
    public class BucketConfig
    {
        private readonly AwsEnvironment awsEnvironment;

        public BucketConfig(AwsEnvironment awsEnvironment)
        {
            this.awsEnvironment = awsEnvironment;
        }

        private string GetBaseBucket()
        {
            return "seeyouapp-";
        }

        private string GetEnvString()
        {
            return awsEnvironment.Prod ? "-prod" : "-test";
        }

        private string GetBucketName(string name)
        {
            return GetBaseBucket() + name + GetEnvString();
        }
        
        public string GetProfilePicturesBucket()
        {
            return GetBucketName("profilepictures");
        }

        public string GetExperienceImagesBucket()
        {
            return GetBucketName("experienceimages");
        }
    }
}