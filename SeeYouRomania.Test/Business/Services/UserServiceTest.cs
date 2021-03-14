using Business.Services;
using Domain;
using Domain.Contracts;
using Domain.DTO;
using Domain.Exceptions;
using Domain.Models;
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

            var invalidUser = new UserEntityDto()
            {
                UserType = null
            };

            Assert.ThrowsExceptionAsync<InvalidInputException>(async () => 
                await userService.Add(invalidUser).ConfigureAwait(false));
        }
    }
}