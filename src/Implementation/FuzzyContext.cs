using System;
using System.Threading;

namespace Fuzzy.Implementation
{
    /// <summary>
    /// Enables fluid API for fuzzy specifications.
    /// </summary>
    public static class FuzzyContext
    {
        static readonly ThreadLocal<object> stored = new ThreadLocal<object>();

        /// <summary>
        /// Associates a fuzzy value with its specification on the current thread.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="spec"/> is <see langword="null"/>.</exception>
        public static void Set<T>(T value, Fuzzy<T> spec) {
            if(spec == null)
                throw new ArgumentNullException(nameof(spec));
            stored.Value = (value, spec);
        }

        /// <summary>
        /// Returns the fuzzy specification most recently stored with <paramref name="value"/> on the current thread.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> does not match the value most recently stored on the current thread.</exception>
        public static TSpec Get<TValue, TSpec>(TValue value) where TSpec : Fuzzy<TValue> {
            (TValue value, Fuzzy<TValue> spec) retrieved = ((TValue, Fuzzy<TValue>))stored.Value;
            EnsureValueWasPreviouslyStored(value, retrieved.value);
            return (TSpec)retrieved.spec;
        }

        static void EnsureValueWasPreviouslyStored<TValue>(TValue value, TValue stored) {
            if(!Equals(value, stored))
                throw new ArgumentException($"{value} is not a fuzzy value.", nameof(value));
        }
    }
}
