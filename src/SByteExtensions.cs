using System;

namespace Fuzzy
{
    public static class SByteExtensions
    {
        public static Fuzzy<sbyte> Between(this Fuzzy<sbyte> fuzzy, sbyte min, sbyte max)
            => throw new NotImplementedException();

        public static Fuzzy<sbyte> GreaterThan(this Fuzzy<sbyte> fuzzy, sbyte min)
            => throw new NotImplementedException();

        public static Fuzzy<sbyte> LessThan(this Fuzzy<sbyte> fuzzy, sbyte max)
            => throw new NotImplementedException();

        public static Fuzzy<sbyte> Not(this Fuzzy<sbyte> fuzzy, sbyte unexpected)
            => throw new NotImplementedException();
    }
}
