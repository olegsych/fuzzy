using System;
using System.Collections.Generic;
using System.Linq;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides <see cref="IFuzz"/> extension methods that produce fuzzy dictionaries.
    /// </summary>
    public static class IFuzzDictionaryExtensions
    {
        /// <summary>Returns a fuzzy dictionary whose keys are produced by <paramref name="createKey"/> and values are produced by <paramref name="createValue"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="createKey"/> is <see langword="null"/>.</exception>
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TValue> createValue, Count? count = default)
            => fuzzy.Dictionary(createKey, k => createValue(), count);

        /// <summary>Returns a fuzzy dictionary whose keys are produced by <paramref name="createKey"/> and whose values are produced by <paramref name="createValue"/> from each key.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/>, <paramref name="createKey"/>, or <paramref name="createValue"/> is <see langword="null"/>.</exception>
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TKey, TValue> createValue, Count? count = default)
            => new FuzzyDictionary<TKey, TValue>(fuzzy, createKey, createValue, count ?? new Count());

        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, IReadOnlyDictionary<TKey, TValue> elements, Count? count = default)
            => fuzzy.Dictionary(() => fuzzy.Element(elements).Key, k => elements[k], count);
    }
}
