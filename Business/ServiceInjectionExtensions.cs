using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Business.Services;
using Domain.AWS;
using Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Business
{
    public static class ServiceInjectionExtensions
    {
        public static void SetupAwsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AwsEnvironment>(configuration.GetSection("AwsEnvironment"));
            services.AddSingleton(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<AwsEnvironment>>().Value);
            services.AddSingleton(typeof(CognitoAWSCredentials), (implFactory) =>
            {
                AwsEnvironment awsEnvironment = implFactory.GetService<AwsEnvironment>();
                return new CognitoAWSCredentials(awsEnvironment.IdentityPoolId,
                    RegionEndpoint.GetBySystemName(awsEnvironment.Region));
            });
            services.AddSingleton(typeof(IAuthService), typeof(CognitoAuthService));

            services.AddSingleton(typeof(AmazonS3Client), (implFactort) =>
            {
                CognitoAWSCredentials credentials = implFactort.GetService<CognitoAWSCredentials>();
                return new AmazonS3Client(credentials);
            });
            services.AddSingleton(typeof(BucketConfig),
                (implFactory) =>
                {
                    AwsEnvironment awsEnvironment = implFactory.GetService<AwsEnvironment>();
                    return new BucketConfig(awsEnvironment);
                });
            services.AddSingleton(typeof(IImageStorageService), typeof(S3ImageStorageService));
        }
    }
}