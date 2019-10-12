using System;
using System.Collections.Generic;

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static T[] Array<T>(this IFuzz fuzzy, Func<T> createElement, Length length = default) => throw new NotImplementedException();
        public static T[] Array<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length length = default) => throw new NotImplementedException();

        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy) => throw new NotImplementedException();
        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy, IBuilder<DateTimeOffset> builder) => throw new NotImplementedException();

        public static string String(this IFuzz fuzzy) => throw new NotImplementedException();
        public static string String(this IFuzz fuzzy, Length length) => throw new NotImplementedException();
        public static string String(this IFuzz fuzzy, IBuilder<string> builder) => throw new NotImplementedException();
        public static string String(this IFuzz fuzzy, IBuilder<string> builder, Length length) => throw new NotImplementedException();
    }
}
