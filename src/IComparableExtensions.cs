using System;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IComparableExtensions {

        public static T Between<T>(this T value, T minimum, T maximum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Minimum = minimum;
            spec.Maximum = maximum;
            return spec;
        }

        public static T Minimum<T>(this T value, T minimum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Minimum = minimum;
            return spec;
        }

        public static T Maximum<T>(this T value, T maximum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Maximum = maximum;
            return spec;
        }
    }
}
