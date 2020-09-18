namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class Int16Extensions
    {
        public static FuzzyRange<short> Between(this FuzzyRange<short> value, short minimum, short maximum) => FuzzyRangeExtensions.Between(value, minimum, maximum);
        public static FuzzyRange<short> Maximum(this FuzzyRange<short> value, short maximum) => FuzzyRangeExtensions.Maximum(value, maximum);
        public static FuzzyRange<short> Minimum(this FuzzyRange<short> value, short minimum) => FuzzyRangeExtensions.Minimum(value, minimum);
    }
}
