using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class DefaultUserValidator
    {
        public virtual bool IsValid(UserEntity userEntity)
        {
            return false;
        }
    }
}