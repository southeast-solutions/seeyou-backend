using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Domain.Request.UserOperations;

namespace Domain.Request.Other
{
    public static class RequestExtensions
    {
        public static UserEntity ToModel(this UserEntityRequest userEntity)
        {
            if (userEntity.UserType == UserTypes.Promoter.ToString())
            {
                return new PromoterEntity()
                {
                    UserType = UserTypes.Promoter,
                    City = userEntity.City,
                    Country = userEntity.Country,
                    CurrentJob = userEntity.CurrentJob,
                    DisponibilityDescription = userEntity.DisponibilityDescription,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    ForeignLanguages = userEntity.ForeignLanguages,
                    IsStudent = userEntity.IsStudent,
                    SocialLinks = userEntity.SocialLinks,
                    ProfilePictureUrl = userEntity.ProfilePictureUrl,
                    PhoneNumber = userEntity.PhoneNumber
                };
            }
            
            if (userEntity.UserType == UserTypes.ContentCreator.ToString())
            {
                return new ContentCreatorEntity()
                {
                    UserType = UserTypes.ContentCreator,
                    City = userEntity.City,
                    DisponibilityDescription = userEntity.DisponibilityDescription,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    ForeignLanguages = userEntity.ForeignLanguages,
                    SocialLinks = userEntity.SocialLinks,
                    ProfilePictureUrl = userEntity.ProfilePictureUrl
                };
            }
            
            if (userEntity.UserType == UserTypes.Concierge.ToString())
            {
                return new ConciergeEntity()
                {
                    UserType = UserTypes.Concierge,
                    City = userEntity.City,
                    Country = userEntity.Country,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    ForeignLanguages = userEntity.ForeignLanguages,
                    SocialLinks = userEntity.SocialLinks,
                    ProfilePictureUrl = userEntity.ProfilePictureUrl
                };
            }

            if (userEntity.UserType == UserTypes.Admin.ToString())
            {
                return new AdminEntity()
                {
                    UserType = UserTypes.Admin,
                    City = userEntity.City,
                    Country = userEntity.Country,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    ForeignLanguages = userEntity.ForeignLanguages,
                    SocialLinks = userEntity.SocialLinks,
                    ProfilePictureUrl = userEntity.ProfilePictureUrl
                };
            }

            if (userEntity.UserType == UserTypes.Tour.ToString())
            {
                return new TourEntity()
                {
                    UserType = UserTypes.Tour,
                    TourBusinessEntity = new TourBusinessEntity()
                    {
                        Address = userEntity.TourBusinessEntity.Address,
                        BusinessName = userEntity.TourBusinessEntity.BusinessName,
                        Cui = userEntity.TourBusinessEntity.Cui,
                        SocialLinks = userEntity.TourBusinessEntity.SocialLinks,
                        Website = userEntity.TourBusinessEntity.Website
                    },
                    TourOperatorEntity = new TourOperatorEntity() 
                    {
                        City = userEntity.TourOperatorEntity.City,
                        FirstName = userEntity.TourOperatorEntity.FirstName,
                        LastName = userEntity.TourOperatorEntity.LastName,
                        ForeignLanguages = userEntity.TourOperatorEntity.ForeignLanguages,
                        SocialLinks = userEntity.TourOperatorEntity.SocialLinks
                    },
                    ProfilePictureUrl = userEntity.ProfilePictureUrl
                };
            }

            throw new InvalidInputException();
        }
    }
}
