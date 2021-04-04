using Domain.Enums;

namespace Business.Validators
{
    public static class UserValidatorFactory
    {
        public static DefaultUserValidator GetValidator(string userType)
        {
            switch (userType)
            {
                case (UserTypes.Promoter):
                    return new PromoterEntityValidator();
                case (UserTypes.Concierge):
                    return new ConciergeUserValidator();
                case (UserTypes.ContentCreator):
                    return new ContentCreatorUserValidator();
                case (UserTypes.Tour):
                    return new TourUserValidator();
                default:
                    return new DefaultUserValidator();
            }
        }
    }
}