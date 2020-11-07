using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzDictionaryExtensions
    {
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TValue> createValue, Count count = default) => throw new NotImplementedException();
        public static Fuzzy<Dictionary<TKey, TValue>> Dictionary<TKey, TValue>(this IFuzz fuzzy, IEnumerable<KeyValuePair<TKey, TValue>> elements, Count count = default) => throw new NotImplementedException();
    }
}
