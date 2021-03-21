using Business.Validators.Fields;
using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class PromoterEntityValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            PromoterEntity promoterEntity = (PromoterEntity)userEntity;

            return new CityFieldValidator().IsValid(promoterEntity.City)
                && new CountryFieldValidator().IsValid(promoterEntity.Country)
                && new CurrentJobFieldValidator().IsValid(promoterEntity.CurrentJob)
                && new DisponibilityDescriptionFieldValidator().IsValid(promoterEntity.DisponibilityDescription)
                && new FirstNameFieldValidator().IsValid(promoterEntity.FirstName)
                && new ForeignLanguagesFieldValidator().IsValid(promoterEntity.ForeignLanguages)
                && new LastNameFieldValidator().IsValid(promoterEntity.LastName)
                && new SocialLinksFieldValidator().IsValid(promoterEntity.SocialLinks);
        }
    }
}