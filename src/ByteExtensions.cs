using System;

namespace Fuzzy
{
    public static class ByteExtensions
    {
        public static Fuzzy<byte> Between(this Fuzzy<byte> fuzzy, byte min, byte max)
            => throw new NotImplementedException();

        public static Fuzzy<byte> GreaterThan(this Fuzzy<byte> fuzzy, byte min)
            => throw new NotImplementedException();

        public static Fuzzy<byte> LessThan(this Fuzzy<byte> fuzzy, byte max)
            => throw new NotImplementedException();

        public static Fuzzy<byte> Not(this Fuzzy<byte> fuzzy, byte unexpected)
            => throw new NotImplementedException();
    }
}
