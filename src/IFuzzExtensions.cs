using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides extension methods that produce fuzzy values of built-in .NET types from an <see cref="IFuzz"/>.
    /// </summary>
    public static class IFuzzExtensions
    {
        /// <summary>Returns a fuzzy <see langword="bool"/>.</summary>
        public static bool Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy);

        /// <summary>Returns a fuzzy <see langword="byte"/>.</summary>
        public static byte Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy);

        /// <summary>Returns a fuzzy <see langword="char"/>.</summary>
        public static char Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy);

        /// <summary>Returns a fuzzy <see cref="System.DateTime"/>.</summary>
        public static DateTime DateTime(this IFuzz fuzzy) => new FuzzyDateTime(fuzzy);

        /// <summary>Returns a fuzzy <see cref="System.DateTime"/> with the specified <see cref="DateTimeKind"/>.</summary>
        public static DateTime DateTime(this IFuzz fuzzy, DateTimeKind kind) => new FuzzyDateTime(fuzzy, kind);

        /// <summary>Returns a fuzzy <see cref="System.DateTimeOffset"/>.</summary>
        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy) => new FuzzyDateTimeOffset(fuzzy);

        /// <summary>Returns a fuzzy <see langword="double"/>.</summary>
        public static double Double(this IFuzz fuzzy) => new FuzzyDouble(fuzzy);

        /// <summary>Returns a fuzzy element chosen from <paramref name="candidates"/>.</summary>
        public static T Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => new FuzzyElement<T>(fuzzy, candidates);

        /// <summary>Returns a fuzzy value of the enumeration type <typeparamref name="T"/>.</summary>
        public static T Enum<T>(this IFuzz fuzzy) where T : Enum => new FuzzyEnum<T>(fuzzy);

        /// <summary>Returns a fuzzy index into <paramref name="elements"/>.</summary>
        public static int Index<T>(this IFuzz fuzzy, IEnumerable<T> elements) => new FuzzyIndex<T>(fuzzy, elements);

        /// <summary>Returns a fuzzy <see langword="short"/>.</summary>
        public static short Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy);

        /// <summary>Returns a fuzzy <see langword="int"/>.</summary>
        public static int Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy);

        /// <summary>Returns a fuzzy <see langword="long"/>.</summary>
        public static long Int64(this IFuzz fuzzy) => new FuzzyInt64(fuzzy);

        /// <summary>Returns a fuzzy <see langword="sbyte"/>.</summary>
        public static sbyte SByte(this IFuzz fuzzy) => new FuzzySByte(fuzzy);

        /// <summary>Returns a fuzzy <see langword="float"/>.</summary>
        public static float Single(this IFuzz fuzzy) => new FuzzySingle(fuzzy);

        /// <summary>Returns a fuzzy <see langword="string"/>.</summary>
        public static string String(this IFuzz fuzzy) => new FuzzyString(fuzzy);

        /// <summary>Returns a fuzzy <see langword="string"/> whose size is constrained by <paramref name="length"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="length"/> is <see langword="null"/>.</exception>
        public static string String(this IFuzz fuzzy, Length length) => new FuzzyString(fuzzy, length ?? throw new ArgumentNullException(nameof(length)), null);

        /// <summary>Returns a fuzzy <see cref="System.TimeSpan"/>.</summary>
        public static TimeSpan TimeSpan(this IFuzz fuzzy) => new FuzzyTimeSpan(fuzzy);

        /// <summary>Returns a fuzzy <see langword="ushort"/>.</summary>
        public static ushort UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy);

        /// <summary>Returns a fuzzy <see langword="uint"/>.</summary>
        public static uint UInt32(this IFuzz fuzzy) => new FuzzyUInt32(fuzzy);

        /// <summary>Returns a fuzzy <see langword="ulong"/>.</summary>
        public static ulong UInt64(this IFuzz fuzzy) => new FuzzyUInt64(fuzzy);

        /// <summary>Returns a fuzzy <see cref="System.Uri"/>.</summary>
        public static Uri Uri(this IFuzz fuzzy) => new FuzzyUri(fuzzy);
    }
}
