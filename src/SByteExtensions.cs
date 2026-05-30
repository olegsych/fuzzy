namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="sbyte"/> values.</summary>
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class SByteExtensions
    {
        /// <inheritdoc cref="IComparableExtensions.Between{T}(T, T, T)"/>
        public static sbyte Between(this sbyte value, sbyte minimum, sbyte maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <inheritdoc cref="IComparableExtensions.Maximum{T}(T, T)"/>
        public static sbyte Maximum(this sbyte value, sbyte maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <inheritdoc cref="IComparableExtensions.Minimum{T}(T, T)"/>
        public static sbyte Minimum(this sbyte value, sbyte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
