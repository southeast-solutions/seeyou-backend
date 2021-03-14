using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class TourUserValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            return true;
        }
    }
}