using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzArrayExtensions
    {
        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<T> createElement, Length length = default) =>
            new FuzzyArray<T>(fuzzy, createElement, length ?? new Length());

        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<Fuzzy<T>> createElement, Length length = default) =>
            fuzzy.Array(() => (T)createElement(), length);

        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<FuzzyRange<T>> createElement, Length length = default) where T : struct, IComparable<T> =>
            fuzzy.Array((Func<Fuzzy<T>>)createElement, length);

        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length length = default) =>
            fuzzy.Array(() => fuzzy.Element(elements), length);
    }
}
