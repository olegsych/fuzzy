using System;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see cref="IComparable{T}"/> values.</summary>
    public static class IComparableExtensions {

        /// <summary>Returns a fuzzy value constrained to the range between <paramref name="minimum"/> and <paramref name="maximum"/>, inclusive.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than <paramref name="maximum"/>.</exception>
        public static T Between<T>(this T value, T minimum, T maximum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Minimum = minimum;
            spec.Maximum = maximum;
            return spec;
        }

        /// <summary>Returns a fuzzy value no less than <paramref name="minimum"/>.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minimum"/> is greater than the current maximum of the fuzzy range.</exception>
        public static T Minimum<T>(this T value, T minimum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Minimum = minimum;
            return spec;
        }

        /// <summary>Returns a fuzzy value no greater than <paramref name="maximum"/>.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maximum"/> is less than the current minimum of the fuzzy range.</exception>
        public static T Maximum<T>(this T value, T maximum) where T : struct, IComparable<T> {
            FuzzyRange<T> spec = FuzzyContext.Get<T, FuzzyRange<T>>(value);
            spec.Maximum = maximum;
            return spec;
        }
    }
}
