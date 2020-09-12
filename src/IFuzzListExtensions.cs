using System;
using System.Collections.Generic;

namespace Fuzzy
{
    public static class IFuzzListExtensions
    {
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, Func<T> createElement, Length length = default) => throw new NotImplementedException();
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, Func<Fuzzy<T>> createElement, Length length = default) => throw new NotImplementedException();
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length length = default) => throw new NotImplementedException();
    }
}
