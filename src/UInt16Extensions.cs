using System;

namespace Fuzzy
{
    public static class UInt16Extensions
    {
        public static Fuzzy<ushort> Between(this Fuzzy<ushort> fuzzy, ushort min, ushort max)
            => throw new NotImplementedException();

        public static Fuzzy<ushort> GreaterThan(this Fuzzy<ushort> fuzzy, ushort min)
            => throw new NotImplementedException();

        public static Fuzzy<ushort> LessThan(this Fuzzy<ushort> fuzzy, ushort max)
            => throw new NotImplementedException();

        public static Fuzzy<ushort> Not(this Fuzzy<ushort> fuzzy, ushort unexpected)
            => throw new NotImplementedException();
    }
}
