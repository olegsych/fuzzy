using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static bool Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy);

        public static byte Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy);

        public static char Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy);

        public static DateTime DateTime(this IFuzz fuzzy, DateTimeKind? kind = null) => new FuzzyDateTime(fuzzy, kind);

        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy) => new FuzzyDateTimeOffset(fuzzy);

        public static double Double(this IFuzz fuzzy) => new FuzzyDouble(fuzzy);

        public static T Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => new FuzzyElement<T>(fuzzy, candidates);

        public static T Enum<T>(this IFuzz fuzzy) where T : Enum => new FuzzyEnum<T>(fuzzy);

        public static int Index<T>(this IFuzz fuzzy, IEnumerable<T> elements) => new FuzzyIndex<T>(fuzzy, elements);

        public static short Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy);

        public static int Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy);

        public static long Int64(this IFuzz fuzzy) => new FuzzyInt64(fuzzy);

        public static sbyte SByte(this IFuzz fuzzy) => new FuzzySByte(fuzzy);

        public static float Single(this IFuzz fuzzy) => new FuzzySingle(fuzzy);

        public static string String(this IFuzz fuzzy) => new FuzzyString(fuzzy);
        public static string String(this IFuzz fuzzy, Length length) => throw new NotImplementedException();
        public static string Format(this string s, string format) => throw new NotImplementedException();

        public static TimeSpan TimeSpan(this IFuzz fuzzy) => new FuzzyTimeSpan(fuzzy);

        public static ushort UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy);

        public static uint UInt32(this IFuzz fuzzy) => new FuzzyUInt32(fuzzy);

        public static ulong UInt64(this IFuzz fuzzy) => new FuzzyUInt64(fuzzy);

        public static Uri Uri(this IFuzz fuzzy) => new FuzzyUri(fuzzy);
    }
}
