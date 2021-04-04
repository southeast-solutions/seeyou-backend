using Business.Services;
using Domain;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Domain.Request.UserOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.Business.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void WhenAddingInvalidUserShouldThrowInvalidInputException()
        {
            Mock<IMongoDbRepository<UserEntity>> repository = new Mock<IMongoDbRepository<UserEntity>>();
            var userService = new UserService(repository.Object);

            var invalidUser = new UserEntityRequest()
            {
                UserType = null
            };

            Assert.ThrowsExceptionAsync<InvalidInputException>(async () => 
                await userService.Add(invalidUser).ConfigureAwait(false));
        }
    }
}