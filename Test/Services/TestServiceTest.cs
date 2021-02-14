using Business.Services;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Services
{
    [TestClass]
    public class TestServiceTest
    {
        [TestMethod]
        public void WhenAddIsCalled_ThenTheRepositoryAddShouldBeCalled()
        {
            Mock<IMongoDbRepository<TestEntity>> testRepository = new Mock<IMongoDbRepository<TestEntity>>();
            ITestService testService = new TestService(testRepository.Object);
            testService.Add(new TestEntityDto());
            
            testRepository.Verify(mock => mock.Insert(It.IsAny<TestEntity>()), Times.Once());
        }
    }
}