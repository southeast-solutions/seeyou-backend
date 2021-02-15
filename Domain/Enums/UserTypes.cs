using System;

namespace Domain.Enums
{
    [Flags]
    public enum UserTypes
    {
        Promoter = 0,
        ContentCreator = 1,
        Concierge = 2,
        Tour = 3
    }
}
