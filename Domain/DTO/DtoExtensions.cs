using Domain.Enums;

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
            if (dto.UserType == UserTypes.Promoter.ToString())
            {
                return new PromoterEntity()
                {
                    UserType = UserTypes.Promoter.ToString(),
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
            else if (dto.UserType == UserTypes.ContentCreator.ToString())
            {
                return new ContentCreatorEntity()
                {
                    UserType = UserTypes.ContentCreator.ToString(),
                    City = dto.City,
                    DisponibilityDescription = dto.DisponibilityDescription,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            else if (dto.UserType == UserTypes.Concierge.ToString())
            {
                return new ConciergeEntity()
                {
                    UserType = UserTypes.Concierge.ToString(),
                    City = dto.City,
                    Country = dto.Country,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            //else if (dto.UserType == UserTypes.Tour.ToString())
            else
            {
                return new TourEntity()
                {
                    UserType = UserTypes.Tour.ToString(),
                    TourBusinessData = new TourBusinessData()
                    {
                        Adress = dto.TourBusinessData.Adress,
                        BusinessName = dto.TourBusinessData.BusinessName,
                        Cui = dto.TourBusinessData.Cui,
                        SocialLinks = dto.TourBusinessData.SocialLinks,
                        Website = dto.TourBusinessData.Website
                    },
                    TourOperatorData = new TourOperatorData() 
                    {
                        City = dto.TourOperatorData.City,
                        FirstName = dto.TourOperatorData.FirstName,
                        LastName = dto.TourOperatorData.LastName,
                        ForeignLanguages = dto.TourOperatorData.ForeignLanguages,
                        SocialLinks = dto.TourOperatorData.SocialLinks
                    }
                };
            }
        }
    }
}
