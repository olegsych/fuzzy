using System;

namespace Fuzzy
{
    /// <remarks>
    /// Needed because compiler cannot resolve <see cref="FuzzyRangeExtensions"/> calls made with literal numbers.
    /// </remarks>
    public static class ByteExtensions
    {
        public static FuzzyRange<byte> Between(this FuzzyRange<byte> value, byte minimum, byte maximum) {
            Require(value);
            value.Minimum = minimum;
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<byte> Maximum(this FuzzyRange<byte> value, byte maximum) {
            Require(value);
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<byte> Minimum(this FuzzyRange<byte> value, byte minimum) {
            Require(value);
            value.Minimum = minimum;
            return value;
        }

        static void Require(FuzzyRange<byte> value) {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
