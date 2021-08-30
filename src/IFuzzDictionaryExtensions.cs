using System;
using System.Collections.Generic;
using System.Linq;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzDictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TValue> createValue, Count? count = default)
            => fuzzy.Dictionary(createKey, k => createValue(), count);

        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TKey, TValue> createValue, Count? count = default)
            => new FuzzyDictionary<TKey, TValue>(fuzzy, createKey, createValue, count ?? new Count()).Generate();

        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, IReadOnlyDictionary<TKey, TValue> elements, Count? count = default)
            => fuzzy.Dictionary(() => fuzzy.Element(elements).Key, k => elements[k], count);
    }
}
