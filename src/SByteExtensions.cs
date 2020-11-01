namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class SByteExtensions
    {
        public static sbyte Between(this sbyte value, sbyte minimum, sbyte maximum) => IComparableExtensions.Between(value, minimum, maximum);
        public static sbyte Maximum(this sbyte value, sbyte maximum) => IComparableExtensions.Maximum(value, maximum);
        public static sbyte Minimum(this sbyte value, sbyte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
