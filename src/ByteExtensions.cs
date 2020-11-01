namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="IComparableExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class ByteExtensions
    {
        public static byte Between(this byte value, byte minimum, byte maximum) => IComparableExtensions.Between(value, minimum, maximum);
        public static byte Maximum(this byte value, byte maximum) => IComparableExtensions.Maximum(value, maximum);
        public static byte Minimum(this byte value, byte minimum) => IComparableExtensions.Minimum(value, minimum);
    }
}
