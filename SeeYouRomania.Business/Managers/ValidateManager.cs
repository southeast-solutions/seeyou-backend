using Domain;
using Domain.Constants;
using Domain.Enums;
using Domain.Models;
using System;
using System.Text.RegularExpressions;

namespace Business.Managers
{
    public static class ValidateManager
    {
        public static bool IsUserValid(UserEntity user)
        {
            if (!Enum.IsDefined(typeof(UserTypes), user.UserType))
            {
                return false;
            }
            switch (user.UserType)
            {
                case UserTypes.Promoter:
                    {
                        return IsValidPromoterEntity((PromoterEntity)user);
                    }
                case UserTypes.ContentCreator:
                    {
                        return IsValidContentCreatorEntity((ContentCreatorEntity)user);
                    }
                case UserTypes.Concierge:
                    {
                        return IsValidConciergeEntity((ConciergeEntity)user);
                    }
                case UserTypes.Tour:
                    {
                        return IsValidTourEntity((TourEntity)user);
                    }
                default:
                    return false;
            }
        }

        private static bool IsValidPromoterEntity(PromoterEntity promoter)
        {
            return IsValidCity(promoter.City)
                && IsValidCountry(promoter.Country)
                && IsValidCurrentJob(promoter.CurrentJob)
                && IsValidDisponibilityDescription(promoter.DisponibilityDescription)
                && IsValidFirstName(promoter.FirstName)
                && IsValidForeignLanguages(promoter.ForeignLanguages)
                && IsValidLastName(promoter.LastName)
                && IsValidSocialLinks(promoter.SocialLinks);
        }

        private static bool IsValidContentCreatorEntity(ContentCreatorEntity contentCreator)
        {
            return IsValidCity(contentCreator.City)
                && IsValidDisponibilityDescription(contentCreator.DisponibilityDescription)
                && IsValidFirstName(contentCreator.FirstName)
                && IsValidForeignLanguages(contentCreator.ForeignLanguages)
                && IsValidLastName(contentCreator.LastName)
                && IsValidSocialLinks(contentCreator.SocialLinks);
        }

        private static bool IsValidConciergeEntity(ConciergeEntity concierge)
        {
            return IsValidCity(concierge.City)
                && IsValidCountry(concierge.Country)
                && IsValidFirstName(concierge.FirstName)
                && IsValidForeignLanguages(concierge.ForeignLanguages)
                && IsValidLastName(concierge.LastName)
                && IsValidSocialLinks(concierge.SocialLinks);
        }

        private static bool IsValidTourEntity(TourEntity tour)
        {
            return IsValidAddress(tour.TourBusinessEntity.Address)
                && IsValidBusinessName(tour.TourBusinessEntity.BusinessName)
                && IsValidCui(tour.TourBusinessEntity.Cui)
                && IsValidSocialLinks(tour.TourBusinessEntity.SocialLinks)
                && IsValidWebsite(tour.TourBusinessEntity.Website)
                && IsValidCity(tour.TourOperatorEntity.City)
                && IsValidFirstName(tour.TourOperatorEntity.FirstName)
                && IsValidForeignLanguages(tour.TourOperatorEntity.ForeignLanguages)
                && IsValidLastName(tour.TourOperatorEntity.LastName)
                && IsValidSocialLinks(tour.TourOperatorEntity.SocialLinks);
        }

        private static bool IsValidWebsite(string website)
        {
            Regex rx = new Regex(ValidatorConstants.URI_PATTERN);

            return rx.IsMatch(website);
        }

        private static bool IsValidCui(string cui)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidBusinessName(string businessName)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidAddress(string address)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidSocialLinks(string socialLinks)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidForeignLanguages(string foreignLanguages)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidDisponibilityDescription(string disponibilityDescription)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidCountry(string country)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidCurrentJob(string currentJob)
        {
            throw new NotImplementedException();
        }

        private static bool IsValidCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
