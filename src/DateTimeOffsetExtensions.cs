using System;

namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see cref="DateTimeOffset"/> values.</summary>
    public static class DateTimeOffsetOffsetExtensions
    {
        /// <summary>Returns a fuzzy value constrained to the range between <paramref name="minimum"/> and <paramref name="minimum"/> plus <paramref name="timeSpan"/>, inclusive.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than the current maximum of the fuzzy range, <paramref name="minimum"/> plus <paramref name="timeSpan"/> is less than <paramref name="minimum"/>, or the sum is outside the range of <see cref="DateTimeOffset"/>.</exception>
        public static DateTimeOffset Between(this DateTimeOffset value, DateTimeOffset minimum, TimeSpan timeSpan) => IComparableExtensions.Between(value, minimum, minimum + timeSpan);
    }
}
