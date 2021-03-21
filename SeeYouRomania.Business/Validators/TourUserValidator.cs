using Business.Validators.Fields;
using Domain;
using Domain.Models;

namespace Business.Validators
{
    public class TourUserValidator : DefaultUserValidator
    {
        public override bool IsValid(UserEntity userEntity)
        {
            TourEntity tourEntity = (TourEntity)userEntity;

            return new AddressFieldValidator().IsValid(tourEntity.TourBusinessEntity.Address)
                && new BusinessNameFieldValidator().IsValid(tourEntity.TourBusinessEntity.BusinessName)
                && new CuiFieldValidator().IsValid(tourEntity.TourBusinessEntity.Cui)
                && new SocialLinksFieldValidator().IsValid(tourEntity.TourBusinessEntity.SocialLinks)
                && new WebsiteFieldValidator().IsValid(tourEntity.TourBusinessEntity.Website)
                && new CityFieldValidator().IsValid(tourEntity.TourOperatorEntity.City)
                && new FirstNameFieldValidator().IsValid(tourEntity.TourOperatorEntity.FirstName)
                && new ForeignLanguagesFieldValidator().IsValid(tourEntity.TourOperatorEntity.ForeignLanguages)
                && new LastNameFieldValidator().IsValid(tourEntity.TourOperatorEntity.LastName)
                && new SocialLinksFieldValidator().IsValid(tourEntity.TourOperatorEntity.SocialLinks);
        }
    }
}