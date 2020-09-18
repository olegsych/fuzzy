namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class UInt16Extensions
    {
        public static FuzzyRange<ushort> Between(this FuzzyRange<ushort> value, ushort minimum, ushort maximum) => FuzzyRangeExtensions.Between(value, minimum, maximum);
        public static FuzzyRange<ushort> Maximum(this FuzzyRange<ushort> value, ushort maximum) => FuzzyRangeExtensions.Maximum(value, maximum);
        public static FuzzyRange<ushort> Minimum(this FuzzyRange<ushort> value, ushort minimum) => FuzzyRangeExtensions.Minimum(value, minimum);
    }
}
