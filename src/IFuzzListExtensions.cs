using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzListExtensions
    {
        public static FuzzyList<T> List<T>(this IFuzz fuzzy, Func<T> createElement, Count count = default) =>
            new FuzzyList<T>(fuzzy, createElement, count ?? new Count());

        public static FuzzyList<T> List<T>(this IFuzz fuzzy, IEnumerable<T> elements, Count count = default) =>
            fuzzy.List(() => fuzzy.Element(elements), count);
    }
}
