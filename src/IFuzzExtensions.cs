using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static Fuzzy<bool> Boolean(this IFuzz fuzzy) => new FuzzyBoolean(fuzzy);

        public static Fuzzy<byte> Byte(this IFuzz fuzzy) => new FuzzyByte(fuzzy);

        public static Fuzzy<char> Char(this IFuzz fuzzy) => new FuzzyChar(fuzzy);

        public static Fuzzy<DateTime> DateTime(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<DateTimeOffset> DateTimeOffset(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<decimal> Decimal(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<double> Double(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<T> Element<T>(this IFuzz fuzzy, IEnumerable<T> candidates) => throw new NotImplementedException();

        public static Fuzzy<T> Enum<T>(this IFuzz fuzzy) where T : Enum => throw new NotImplementedException();

        public static Fuzzy<short> Int16(this IFuzz fuzzy) => new FuzzyInt16(fuzzy);

        public static Fuzzy<int> Int32(this IFuzz fuzzy) => new FuzzyInt32(fuzzy);

        public static Fuzzy<long> Int64(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<sbyte> SByte(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<float> Single(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<string> String(this IFuzz fuzzy) => throw new NotImplementedException();
        public static Fuzzy<string> String(this IFuzz fuzzy, Length length) => throw new NotImplementedException();
        public static Fuzzy<string> Format(this Fuzzy<string> s, string format) => throw new NotImplementedException();

        public static Fuzzy<TimeSpan> TimeSpan(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<ushort> UInt16(this IFuzz fuzzy) => new FuzzyUInt16(fuzzy);

        public static Fuzzy<uint> UInt32(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<ulong> UInt64(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<Uri> Uri(this IFuzz fuzzy) => throw new NotImplementedException();
    }
}
