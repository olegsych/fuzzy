using System;

namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see cref="DateTime"/> values.</summary>
    public static class DateTimeExtensions
    {
        /// <summary>Returns a fuzzy value constrained to the range between <paramref name="minimum"/> and <paramref name="minimum"/> plus <paramref name="timeSpan"/>, inclusive.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than the current maximum of the fuzzy range, <paramref name="minimum"/> plus <paramref name="timeSpan"/> is less than <paramref name="minimum"/>, or the sum is outside the range of <see cref="DateTime"/>.</exception>
        public static DateTime Between(this DateTime value, DateTime minimum, TimeSpan timeSpan) => IComparableExtensions.Between(value, minimum, minimum + timeSpan);
    }
}
