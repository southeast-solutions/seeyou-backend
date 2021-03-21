using Business.Validators.Fields;
using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class ConciergeUserValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            ConciergeEntity conciergeEntity = (ConciergeEntity)userEntity;

            return new CityFieldValidator().IsValid(conciergeEntity.City)
                && new CountryFieldValidator().IsValid(conciergeEntity.Country)
                && new FirstNameFieldValidator().IsValid(conciergeEntity.FirstName)
                && new ForeignLanguagesFieldValidator().IsValid(conciergeEntity.ForeignLanguages)
                && new LastNameFieldValidator().IsValid(conciergeEntity.LastName)
                && new SocialLinksFieldValidator().IsValid(conciergeEntity.SocialLinks);
        }
    }
}