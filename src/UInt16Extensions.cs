using System;

namespace Fuzzy
{
    public static class UInt16Extensions
    {
        public static FuzzyRange<ushort> Between(this FuzzyRange<ushort> value, ushort minimum, ushort maximum) {
            Require(value);
            value.Minimum = minimum;
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<ushort> Maximum(this FuzzyRange<ushort> value, ushort maximum) {
            Require(value);
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<ushort> Minimum(this FuzzyRange<ushort> value, ushort minimum) {
            Require(value);
            value.Minimum = minimum;
            return value;
        }

        static void Require(FuzzyRange<ushort> value) {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
