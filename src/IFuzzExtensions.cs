using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

// Extension methods are intentionally named after built-in types they generate
#pragma warning disable CA1720

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static bool Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy).Generate();

        public static byte Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy).Generate();

        public static char Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy).Generate();

        public static DateTime DateTime(this IFuzz fuzzy) => new FuzzyDateTime(fuzzy).Generate();
        public static DateTime DateTime(this IFuzz fuzzy, DateTimeKind kind) => new FuzzyDateTime(fuzzy, kind).Generate();

        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy) => new FuzzyDateTimeOffset(fuzzy).Generate();

        public static double Double(this IFuzz fuzzy) =>new FuzzyDouble(fuzzy).Generate();

        public static T Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => new FuzzyElement<T>(fuzzy, candidates).Generate();

        public static T Enum<T>(this IFuzz fuzzy) where T : Enum => new FuzzyEnum<T>(fuzzy).Generate();

        public static int Index<T>(this IFuzz fuzzy, IEnumerable<T> elements) => new FuzzyIndex<T>(fuzzy, elements).Generate();

        public static short Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy).Generate();

        public static int Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy).Generate();

        public static long Int64(this IFuzz fuzzy) => new FuzzyInt64(fuzzy).Generate();

        public static sbyte SByte(this IFuzz fuzzy) => new FuzzySByte(fuzzy).Generate();

        public static float Single(this IFuzz fuzzy) => new FuzzySingle(fuzzy).Generate();

        public static string String(this IFuzz fuzzy) => new FuzzyString(fuzzy).Generate();
        public static string String(this IFuzz fuzzy, Length length) => new FuzzyString(fuzzy, length ?? throw new ArgumentNullException(nameof(length)), null).Generate();

        public static TimeSpan TimeSpan(this IFuzz fuzzy) => new FuzzyTimeSpan(fuzzy).Generate();

        public static ushort UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy).Generate();

        public static uint UInt32(this IFuzz fuzzy) => new FuzzyUInt32(fuzzy).Generate();

        public static ulong UInt64(this IFuzz fuzzy) => new FuzzyUInt64(fuzzy).Generate();

        public static Uri Uri(this IFuzz fuzzy) => new FuzzyUri(fuzzy).Generate();
    }
}
