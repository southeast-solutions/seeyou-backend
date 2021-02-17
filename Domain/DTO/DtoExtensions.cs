using Domain.Enums;
using Domain.Models;

namespace Domain.DTO
{
    public static class DtoExtensions
    {
        public static TestEntity ToModel(this TestEntityDto dto)
        {
            return new TestEntity()
            {
                MyProperty = dto.MyProperty
            };
        }

        public static ExperienceEntity ToModel(this ExperienceEntityDto dto)
        {
            return new ExperienceEntity()
            {
                Name = dto.Name
            };
        }

        public static UserEntity ToModel(this UserEntityDto dto)
        {
            if (dto.UserType == UserTypes.PROMOTER.ToString())
            {
                return new PromoterEntity()
                {
                    UserType = UserTypes.PROMOTER,
                    City = dto.City,
                    Country = dto.Country,
                    CurrentJob = dto.CurrentJob,
                    DisponibilityDescription = dto.DisponibilityDescription,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    IsStudent = dto.IsStudent,
                    SocialLinks = dto.SocialLinks
                };
            }
            else if (dto.UserType == UserTypes.CONTENTCREATOR.ToString())
            {
                return new ContentCreatorEntity()
                {
                    UserType = UserTypes.CONTENTCREATOR,
                    City = dto.City,
                    DisponibilityDescription = dto.DisponibilityDescription,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            else if (dto.UserType == UserTypes.CONCIERGE.ToString())
            {
                return new ConciergeEntity()
                {
                    UserType = UserTypes.CONCIERGE,
                    City = dto.City,
                    Country = dto.Country,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            else if (dto.UserType == UserTypes.TOUR.ToString())
            {
                return new TourEntity()
                {
                    UserType = UserTypes.TOUR,
                    TourBusinessEntity = new TourBusinessEntity()
                    {
                        Adress = dto.TourBusinessEntity.Adress,
                        BusinessName = dto.TourBusinessEntity.BusinessName,
                        Cui = dto.TourBusinessEntity.Cui,
                        SocialLinks = dto.TourBusinessEntity.SocialLinks,
                        Website = dto.TourBusinessEntity.Website
                    },
                    TourOperatorEntity = new TourOperatorEntity() 
                    {
                        City = dto.TourOperatorEntity.City,
                        FirstName = dto.TourOperatorEntity.FirstName,
                        LastName = dto.TourOperatorEntity.LastName,
                        ForeignLanguages = dto.TourOperatorEntity.ForeignLanguages,
                        SocialLinks = dto.TourOperatorEntity.SocialLinks
                    }
                };
            }
            else
            {
                return new UnknownUserEntity()
                {
                    UserType = UserTypes.UNKNOWN
                };
            }
        }
    }
}
