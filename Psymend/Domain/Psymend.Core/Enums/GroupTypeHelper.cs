using System;

namespace Psymend.Core.Enums
{
    public static class GroupTypeHelper
    {
        public static string ToAbbreviation(this GroupType groupType)
        {
            switch (groupType)
            {
                case GroupType.Positive:
                    return "+";
                case GroupType.Spontaneous:
                    return "x";
                case GroupType.Neutral:
                    return "=";
                case GroupType.Negative:
                    return "-";
                default:
                    throw new ArgumentOutOfRangeException(nameof(groupType), groupType, "this type was not found");
            }
        }
    }
}