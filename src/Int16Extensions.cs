namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="short"/> values.</summary>
    // Needed because compiler cannot resolve IComparableExtensions calls made with literal numbers.
    public static class Int16Extensions
    {
        /// <inheritdoc cref="IComparableExtensions.Between{T}(T, T, T)"/>
        public static short Between(this short value, short minimum, short maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <inheritdoc cref="IComparableExtensions.Maximum{T}(T, T)"/>
        public static short Maximum(this short value, short maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <inheritdoc cref="IComparableExtensions.Minimum{T}(T, T)"/>
        public static short Minimum(this short value, short minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
