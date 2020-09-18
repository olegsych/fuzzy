using System;

namespace Fuzzy
{
    public static class Int16Extensions
    {
        public static FuzzyRange<short> Between(this FuzzyRange<short> value, short minimum, short maximum) {
            Require(value);
            value.Minimum = minimum;
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<short> Maximum(this FuzzyRange<short> value, short maximum) {
            Require(value);
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<short> Minimum(this FuzzyRange<short> value, short minimum) {
            Require(value);
            value.Minimum = minimum;
            return value;
        }

        static void Require(FuzzyRange<short> value) {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
