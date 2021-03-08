using System;
using System.Collections.Generic;
using System.Net;
using Business;
using Business.Services;
using DataAccess;
using Domain;
using Domain.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"}); });
            services.AddLogging();
            
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            
            services.AddTransient(typeof(IMongoDbRepository<>), typeof(MongoDbRepository<>));
            services.AddSingleton(typeof(IExperienceService), typeof(ExperienceService));
            services.AddSingleton(typeof(IUserService), typeof(UserService));
            
            services.SetupAwsServices(Configuration);
            // services.AddAuthentication()
            //     .AddJwtBearer(options => options.TokenValidationParameters = GetTokenValidationParams());
        }

        private TokenValidationParameters GetTokenValidationParams()
        {
            Console.WriteLine(Configuration["AwsEnvironment.Region"]);
            var cognitoIssuer = $"https://cognito-idp.{Configuration["AwsEnvironment.Region"]}.amazonaws.com/{Configuration["userPoolId"]}";
            var jwtKeySetUrl = $"{cognitoIssuer}/.well-known/jwks.json";
            var cognitoAudience = Configuration["appClientId"];

            return new TokenValidationParameters
            {
                IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) =>
                {
                    var json = new WebClient().DownloadString(jwtKeySetUrl);
                    var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(json)?.Keys;
                    return (IEnumerable<SecurityKey>)keys;
                },
                ValidIssuer = cognitoIssuer,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidAudience = cognitoAudience
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
