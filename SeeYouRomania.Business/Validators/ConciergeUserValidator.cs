using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class ConciergeUserValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            return true;
        }
    }
}