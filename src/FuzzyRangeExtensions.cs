using System;

namespace Fuzzy
{
    public static class FuzzyRangeExtensions
    {
        public static FuzzyRange<T> Between<T>(this FuzzyRange<T> value, T minimum, T maximum) where T : struct, IComparable<T> {
            Require(value);
            value.Minimum = minimum;
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<T> Maximum<T>(this FuzzyRange<T> value, T maximum) where T : struct, IComparable<T> {
            Require(value);
            value.Maximum = maximum;
            return value;
        }

        public static FuzzyRange<T> Minimum<T>(this FuzzyRange<T> value, T minimum) where T : struct, IComparable<T> {
            Require(value);
            value.Minimum = minimum;
            return value;
        }

        static void Require<T>(FuzzyRange<T> value) where T : struct, IComparable<T> {
            if(value == null)
                throw new ArgumentNullException(nameof(value));
        }
    }
}
