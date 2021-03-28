using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
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
            services.AddSingleton(typeof(ImmutableCredentials), 
                (implFactory) => implFactory.GetService<CognitoAWSCredentials>());
            
            services.AddSingleton(typeof(IAmazonS3), (implFactory) =>
            {
                CognitoAWSCredentials credentials = implFactory.GetService<CognitoAWSCredentials>();
                AwsEnvironment environment = implFactory.GetService<AwsEnvironment>();
                return new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(environment.Region));
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