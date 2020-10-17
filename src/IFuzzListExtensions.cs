using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzListExtensions
    {
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, Func<T> createElement, Count count = default) =>
            new FuzzyList<T>(fuzzy, createElement, count ?? new Count());

        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, Func<Fuzzy<T>> createElement, Count count = default) => throw new NotImplementedException();
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, Func<FuzzyRange<T>> createElement, Count count = default) where T: struct, IComparable<T>
            => throw new NotImplementedException();
        public static Fuzzy<List<T>> List<T>(this IFuzz fuzzy, IEnumerable<T> elements, Count count = default) => throw new NotImplementedException();
    }
}
