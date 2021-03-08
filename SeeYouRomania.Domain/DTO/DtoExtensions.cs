﻿using Domain.Enums;
using Domain.Models;

namespace Domain.DTO
{
    public static class DtoExtensions
    {
        //public static ExperienceEntity ToModel(this ExperienceEntityDto dto)
        //{
        //    return new ExperienceEntity()
        //    {
        //        Name = dto.Name
        //    };
        //}

        public static UserEntity ToModel(this UserEntityDto dto)
        {
            if (dto.UserType == UserTypes.Promoter.ToString())
            {
                return new PromoterEntity()
                {
                    UserType = UserTypes.Promoter,
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
            
            if (dto.UserType == UserTypes.ContentCreator.ToString())
            {
                return new ContentCreatorEntity()
                {
                    UserType = UserTypes.ContentCreator,
                    City = dto.City,
                    DisponibilityDescription = dto.DisponibilityDescription,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            
            if (dto.UserType == UserTypes.Concierge.ToString())
            {
                return new ConciergeEntity()
                {
                    UserType = UserTypes.Concierge,
                    City = dto.City,
                    Country = dto.Country,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ForeignLanguages = dto.ForeignLanguages,
                    SocialLinks = dto.SocialLinks
                };
            }
            
            if (dto.UserType == UserTypes.Tour.ToString())
            {
                return new TourEntity()
                {
                    UserType = UserTypes.Tour,
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

            return new UnknownUserEntity()
            {
                UserType = UserTypes.Unknown
            };
        }
    }
}