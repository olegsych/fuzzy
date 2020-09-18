using System;
using System.Collections.Generic;

namespace Fuzzy
{
    public static class IFuzzDictionaryExtensions
    {
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TValue> createValue, Count count = default) => throw new NotImplementedException();
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<Fuzzy<TKey>> createKey, Func<Fuzzy<TValue>> createValue, Count count = default) => throw new NotImplementedException();
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<FuzzyRange<TKey>> createKey, Func<Fuzzy<TValue>> createValue, Count count = default)
            where TKey: struct, IComparable<TKey>
            => throw new NotImplementedException();
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, IEnumerable<KeyValuePair<TKey, TValue>> elements, Count count = default) => throw new NotImplementedException();
    }
}
