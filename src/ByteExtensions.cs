namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class ByteExtensions
    {
        public static FuzzyRange<byte> Between(this FuzzyRange<byte> value, byte minimum, byte maximum) => FuzzyRangeExtensions.Between(value, minimum, maximum);
        public static FuzzyRange<byte> Maximum(this FuzzyRange<byte> value, byte maximum) => FuzzyRangeExtensions.Maximum(value, maximum);
        public static FuzzyRange<byte> Minimum(this FuzzyRange<byte> value, byte minimum) => FuzzyRangeExtensions.Minimum(value, minimum);
    }
}
