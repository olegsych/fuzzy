namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class UInt16Extensions
    {
        public static ushort Between(this ushort value, ushort minimum, ushort maximum) => IComparableExtensions.Between(value, minimum, maximum);
        public static ushort Maximum(this ushort value, ushort maximum) => IComparableExtensions.Maximum(value, maximum);
        public static ushort Minimum(this ushort value, ushort minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
