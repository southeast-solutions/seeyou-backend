using Business.Validators;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Business.Validators
{
    [TestClass]
    public class DefaultUserValidatorTest
    {
        [TestMethod]
        public void WhenCheckingForIsValidShouldReturnTrue()
        {
            DefaultUserValidator validator = new DefaultUserValidator();
            var userEntity = new TourEntity();
            
            Assert.IsFalse(validator.IsValid(userEntity));
        }
    }
}