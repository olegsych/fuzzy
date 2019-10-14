using System;

namespace Fuzzy
{
    public static class Int16Extensions
    {
        public static Fuzzy<short> Between(this Fuzzy<short> fuzzy, short min, short max)
            => throw new NotImplementedException();

        public static Fuzzy<short> GreaterThan(this Fuzzy<short> fuzzy, short min)
            => throw new NotImplementedException();

        public static Fuzzy<short> LessThan(this Fuzzy<short> fuzzy, short max)
            => throw new NotImplementedException();

        public static Fuzzy<short> Not(this Fuzzy<short> fuzzy, short unexpected)
            => throw new NotImplementedException();
    }
}
