using System;

namespace Fuzzy
{
    public static class DateTimeOffsetOffsetExtensions
    {
        public static DateTimeOffset Between(this DateTimeOffset value, DateTimeOffset minimum, TimeSpan timeSpan) => IComparableExtensions.Between(value, minimum, minimum + timeSpan);
    }
}
