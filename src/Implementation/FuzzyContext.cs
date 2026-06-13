using System;
using System.Threading;

namespace Fuzzy.Implementation
{
    /// <summary>
    /// Enables a fluent API for fuzzy specifications by carrying the originating <see cref="Fuzzy{T}"/> across the call boundary between <see cref="IFuzz.Build{T}"/> and constraint extensions.
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
            // TODO: throw ArgumentException instead of NullReferenceException when nothing was stored on the current thread (csharp.instructions: no low-level exceptions).
            // TODO: throw ArgumentException instead of InvalidCastException when TValue doesn't match the stored value type (csharp.instructions: no low-level exceptions).
            (TValue value, Fuzzy<TValue> spec) retrieved = ((TValue, Fuzzy<TValue>))stored.Value;
            EnsureValueWasPreviouslyStored(value, retrieved.value);
            // TODO: throw ArgumentException instead of InvalidCastException when TSpec doesn't match the stored spec type (csharp.instructions: no low-level exceptions).
            return (TSpec)retrieved.spec;
        }

        static void EnsureValueWasPreviouslyStored<TValue>(TValue value, TValue stored) {
            if(!Equals(value, stored))
                throw new ArgumentException($"{value} is not a fuzzy value.", nameof(value));
        }
    }
}
