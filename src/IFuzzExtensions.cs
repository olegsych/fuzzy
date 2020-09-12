using System;

namespace Fuzzy
{
    public static class IFuzzExtensions
    {
        public static Fuzzy<byte> Byte(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<char> Char(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<DateTime> DateTime(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<DateTimeOffset> DateTimeOffset(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<decimal> Decimal(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<double> Double(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<T> Enum<T>(this IFuzz fuzzy) where T : Enum => throw new NotImplementedException();

        public static Fuzzy<short> Int16(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<int> Int32(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<long> Int64(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<sbyte> SByte(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<float> Single(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<string> String(this IFuzz fuzzy) => throw new NotImplementedException();
        public static Fuzzy<string> String(this IFuzz fuzzy, Length length) => throw new NotImplementedException();
        public static Fuzzy<string> Format(this Fuzzy<string> s, string format) => throw new NotImplementedException();

        public static Fuzzy<TimeSpan> TimeSpan(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<ushort> UInt16(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<uint> UInt32(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<ulong> UInt64(this IFuzz fuzzy) => throw new NotImplementedException();

        public static Fuzzy<Uri> Uri(this IFuzz fuzzy) => throw new NotImplementedException();
    }
}
