using System;

namespace Domain.Enums
{
    [Flags]
    public enum UserTypes
    {
        Unknown,
        Promoter,
        ContentCreator,
        Concierge,
        Tour
    }
}
