using Business.Validators.Fields;
using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class ContentCreatorUserValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            ContentCreatorEntity contentCreatorEntity = (ContentCreatorEntity)userEntity;

            return new CityFieldValidator().IsValid(contentCreatorEntity.City)
                && new DisponibilityDescriptionFieldValidator().IsValid(contentCreatorEntity.DisponibilityDescription)
                && new FirstNameFieldValidator().IsValid(contentCreatorEntity.FirstName)
                && new ForeignLanguagesFieldValidator().IsValid(contentCreatorEntity.ForeignLanguages)
                && new LastNameFieldValidator().IsValid(contentCreatorEntity.LastName)
                && new SocialLinksFieldValidator().IsValid(contentCreatorEntity.SocialLinks);
        }
    }
}