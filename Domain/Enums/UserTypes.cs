using System;

namespace Domain.Enums
{
    [Flags]
    public enum UserTypes
    {
        UNKNOWN,
        PROMOTER,
        CONTENTCREATOR,
        CONCIERGE,
        TOUR
    }
}
