using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzArrayExtensions
    {
        public static T[] Array<T>(this IFuzz fuzzy, Func<T> createElement, Length? length = default) =>
            new FuzzyArray<T>(fuzzy, createElement, length ?? new Length()).Generate();

        public static T[] Array<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length? length = default) =>
            fuzzy.Array(() => fuzzy.Element(elements), length);
    }
}
