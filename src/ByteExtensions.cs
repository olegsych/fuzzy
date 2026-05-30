using System;

namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="byte"/> values.</summary>
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class ByteExtensions
    {
        /// <summary>Returns a fuzzy <see langword="byte"/> value constrained to the range between <paramref name="minimum"/> and <paramref name="maximum"/>, inclusive.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than the current maximum of the fuzzy range, or <paramref name="maximum"/> is less than <paramref name="minimum"/>.</exception>
        public static byte Between(this byte value, byte minimum, byte maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <summary>Returns a fuzzy <see langword="byte"/> value no greater than <paramref name="maximum"/>.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maximum"/> is less than the current minimum of the fuzzy range.</exception>
        public static byte Maximum(this byte value, byte maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <summary>Returns a fuzzy <see langword="byte"/> value no less than <paramref name="minimum"/>.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than the current maximum of the fuzzy range.</exception>
        public static byte Minimum(this byte value, byte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
