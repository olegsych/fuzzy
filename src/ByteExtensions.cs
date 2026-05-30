namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="byte"/> values.</summary>
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class ByteExtensions
    {
        /// <summary>Returns a fuzzy <see langword="byte"/> value constrained to the range between <paramref name="minimum"/> and <paramref name="maximum"/>, inclusive.</summary>
        public static byte Between(this byte value, byte minimum, byte maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <summary>Returns a fuzzy <see langword="byte"/> value no greater than <paramref name="maximum"/>.</summary>
        public static byte Maximum(this byte value, byte maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <summary>Returns a fuzzy <see langword="byte"/> value no less than <paramref name="minimum"/>.</summary>
        public static byte Minimum(this byte value, byte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
