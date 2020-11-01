using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static Fuzzy<bool> Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy);

        public static FuzzyRange<byte> Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy);

        public static FuzzyRange<char> Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy);

        public static FuzzyRange<DateTime> DateTime(this IFuzz fuzzy, DateTimeKind? kind = null) => new FuzzyDateTime(fuzzy, kind);

        public static FuzzyRange<DateTimeOffset> DateTimeOffset(this IFuzz fuzzy) => new FuzzyDateTimeOffset(fuzzy);

        public static Fuzzy<double> Double(this IFuzz fuzzy) => new FuzzyDouble(fuzzy);

        public static T Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => new FuzzyElement<T>(fuzzy, candidates);

        public static T Enum<T>(this IFuzz fuzzy) where T : Enum => new FuzzyEnum<T>(fuzzy);

        public static Fuzzy<int> Index<T>(this IFuzz fuzzy, IEnumerable<T> elements) => new FuzzyIndex<T>(fuzzy, elements);

        public static FuzzyRange<short> Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy);

        public static FuzzyRange<int> Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy);

        public static FuzzyRange<long> Int64(this IFuzz fuzzy) => new FuzzyInt64(fuzzy);

        public static FuzzyRange<sbyte> SByte(this IFuzz fuzzy) => new FuzzySByte(fuzzy);

        public static Fuzzy<float> Single(this IFuzz fuzzy) => new FuzzySingle(fuzzy);

        public static Fuzzy<string> String(this IFuzz fuzzy) => new FuzzyString(fuzzy);
        public static Fuzzy<string> String(this IFuzz fuzzy, Length length) => throw new NotImplementedException();
        public static Fuzzy<string> Format(this Fuzzy<string> s, string format) => throw new NotImplementedException();

        public static FuzzyRange<TimeSpan> TimeSpan(this IFuzz fuzzy) => new FuzzyTimeSpan(fuzzy);

        public static FuzzyRange<ushort> UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy);

        public static FuzzyRange<uint> UInt32(this IFuzz fuzzy) => new FuzzyUInt32(fuzzy);

        public static FuzzyRange<ulong> UInt64(this IFuzz fuzzy) => new FuzzyUInt64(fuzzy);

        public static Fuzzy<Uri> Uri(this IFuzz fuzzy) => new FuzzyUri(fuzzy);
    }
}
