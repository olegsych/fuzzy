namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="byte"/> values.</summary>
    // Needed because compiler cannot resolve IComparableExtensions calls made with literal numbers.
    public static class ByteExtensions
    {
        /// <inheritdoc cref="IComparableExtensions.Between{T}(T, T, T)"/>
        public static byte Between(this byte value, byte minimum, byte maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <inheritdoc cref="IComparableExtensions.Maximum{T}(T, T)"/>
        public static byte Maximum(this byte value, byte maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <inheritdoc cref="IComparableExtensions.Minimum{T}(T, T)"/>
        public static byte Minimum(this byte value, byte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
