namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class SByteExtensions
    {
        public static FuzzyRange<sbyte> Between(this FuzzyRange<sbyte> value, sbyte minimum, sbyte maximum) => FuzzyRangeExtensions.Between(value, minimum, maximum);
        public static FuzzyRange<sbyte> Maximum(this FuzzyRange<sbyte> value, sbyte maximum) => FuzzyRangeExtensions.Maximum(value, maximum);
        public static FuzzyRange<sbyte> Minimum(this FuzzyRange<sbyte> value, sbyte minimum) => FuzzyRangeExtensions.Minimum(value, minimum);
    }
}
