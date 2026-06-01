using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides <see cref="IFuzz"/> extension methods that produce fuzzy values of common .NET types
    /// and pick fuzzy elements or indexes from a sequence.
    /// </summary>
    public static class IFuzzExtensions
    {
        /// <summary>Returns a fuzzy <see langword="bool"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static bool Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy);

        /// <summary>Returns a fuzzy <see langword="byte"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static byte Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy);

        /// <summary>Returns a fuzzy <see langword="char"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static char Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy);

        /// <summary>Returns a fuzzy <see cref="System.DateTime"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static DateTime DateTime(this IFuzz fuzzy) => new FuzzyDateTime(fuzzy);

        /// <summary>Returns a fuzzy <see cref="System.DateTime"/> with the specified <see cref="DateTimeKind"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static DateTime DateTime(this IFuzz fuzzy, DateTimeKind kind) => new FuzzyDateTime(fuzzy, kind);

        /// <summary>Returns a fuzzy <see cref="DateTimeOffset"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static DateTimeOffset DateTimeOffset(this IFuzz fuzzy) => new FuzzyDateTimeOffset(fuzzy);

        /// <summary>Returns a fuzzy <see langword="double"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static double Double(this IFuzz fuzzy) => new FuzzyDouble(fuzzy);

        /// <summary>Returns a fuzzy element chosen from <paramref name="candidates"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="candidates"/> is <see langword="null"/>.</exception>
        public static T Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => new FuzzyElement<T>(fuzzy, candidates);

        /// <summary>Returns a fuzzy value defined by the enumeration type <typeparamref name="T"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static T Enum<T>(this IFuzz fuzzy) where T : Enum => new FuzzyEnum<T>(fuzzy);

        /// <summary>Returns a fuzzy index into <paramref name="elements"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="elements"/> is <see langword="null"/>.</exception>
        // TODO: When elements is empty, an internal ArgumentOutOfRangeException (ParamName == "value") leaks from the
        // FuzzyRange.Maximum setter via Between(0, -1), instead of a domain-appropriate exception about elements.
        public static int Index<T>(this IFuzz fuzzy, IEnumerable<T> elements) => new FuzzyIndex<T>(fuzzy, elements);

        /// <summary>Returns a fuzzy <see langword="short"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static short Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy);

        /// <summary>Returns a fuzzy <see langword="int"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static int Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy);

        /// <summary>Returns a fuzzy <see langword="long"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static long Int64(this IFuzz fuzzy) => new FuzzyInt64(fuzzy);

        /// <summary>Returns a fuzzy <see langword="sbyte"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static sbyte SByte(this IFuzz fuzzy) => new FuzzySByte(fuzzy);

        /// <summary>Returns a fuzzy <see langword="float"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static float Single(this IFuzz fuzzy) => new FuzzySingle(fuzzy);

        /// <summary>Returns a fuzzy <see langword="string"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static string String(this IFuzz fuzzy) => new FuzzyString(fuzzy);

        /// <summary>Returns a fuzzy <see langword="string"/> whose length is constrained by <paramref name="length"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="length"/> is <see langword="null"/>.</exception>
        public static string String(this IFuzz fuzzy, Length length) => new FuzzyString(fuzzy, length ?? throw new ArgumentNullException(nameof(length)), null);

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static TimeSpan TimeSpan(this IFuzz fuzzy) => new FuzzyTimeSpan(fuzzy);

        /// <summary>Returns a fuzzy <see langword="ushort"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static ushort UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy);

        /// <summary>Returns a fuzzy <see langword="uint"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static uint UInt32(this IFuzz fuzzy) => new FuzzyUInt32(fuzzy);

        /// <summary>Returns a fuzzy <see langword="ulong"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static ulong UInt64(this IFuzz fuzzy) => new FuzzyUInt64(fuzzy);

        /// <summary>Returns a fuzzy <see cref="Uri"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public static Uri Uri(this IFuzz fuzzy) => new FuzzyUri(fuzzy);
    }
}
