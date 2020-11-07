using System;

namespace Fuzzy
{
    public static class DateTimeExtensions
    {
        public static DateTime Between(this DateTime value, DateTime minimum, TimeSpan timeSpan) => IComparableExtensions.Between(value, minimum, minimum + timeSpan);
    }
}
