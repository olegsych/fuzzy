using System;
using System.Collections.Generic;

namespace Fuzzy
{
    public static class IFuzzArrayExtensions
    {
        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<T> createElement) => throw new NotImplementedException();
        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<Fuzzy<T>> createElement) => throw new NotImplementedException();

        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<T> createElement, Length length) => throw new NotImplementedException();
        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, Func<Fuzzy<T>> createElement, Length length) => throw new NotImplementedException();

        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, IEnumerable<T> elements) => throw new NotImplementedException();
        public static Fuzzy<T[]> Array<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length length) => throw new NotImplementedException();
    }
}
