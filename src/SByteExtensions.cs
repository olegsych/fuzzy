using System;

namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class SByteExtensions
    {
        public static FuzzyRange<sbyte> Between(this FuzzyRange<sbyte> value, sbyte minimum, sbyte maximum) {
            Require(value);
            value.Minimum = minimum;
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<sbyte> Maximum(this FuzzyRange<sbyte> value, sbyte maximum) {
            Require(value);
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<sbyte> Minimum(this FuzzyRange<sbyte> value, sbyte minimum) {
            Require(value);
            value.Minimum = minimum;
            return value;
        }

        static void Require(FuzzyRange<sbyte> value) {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
