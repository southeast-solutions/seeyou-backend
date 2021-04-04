using Business.Services;
using Domain;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Request.Experiences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Business.Services
{
    [TestClass]
    public class ExperienceServiceTest
    {
        [TestMethod]
        public void WhenAddingExperienceWithEmptyUserIdShouldThrowInvalidUserIdException()
        {
            Mock<IMongoDbRepository<ExperienceEntity>> repository = new Mock<IMongoDbRepository<ExperienceEntity>>();
            var experienceService = new ExperienceService(repository.Object);

            var invalidExperience = new AddExperienceRequest()
            {
            };

            Assert.ThrowsExceptionAsync<InvalidInputException>(async () => 
                await experienceService.Add(invalidExperience, "").ConfigureAwait(false));
        }
    }
}