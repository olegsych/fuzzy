namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class Int16Extensions
    {
        public static short Between(this short value, short minimum, short maximum) => IComparableExtensions.Between(value, minimum, maximum);
        public static short Maximum(this short value, short maximum) => IComparableExtensions.Maximum(value, maximum);
        public static short Minimum(this short value, short minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
