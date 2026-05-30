namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see langword="ushort"/> values.</summary>
    // Needed because compiler cannot resolve IComparableExtensions calls made with literal numbers.
    public static class UInt16Extensions
    {
        /// <inheritdoc cref="IComparableExtensions.Between{T}(T, T, T)"/>
        public static ushort Between(this ushort value, ushort minimum, ushort maximum) => IComparableExtensions.Between(value, minimum, maximum);

        /// <inheritdoc cref="IComparableExtensions.Maximum{T}(T, T)"/>
        public static ushort Maximum(this ushort value, ushort maximum) => IComparableExtensions.Maximum(value, maximum);

        /// <inheritdoc cref="IComparableExtensions.Minimum{T}(T, T)"/>
        public static ushort Minimum(this ushort value, ushort minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
