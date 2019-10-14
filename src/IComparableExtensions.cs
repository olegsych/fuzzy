using System;

namespace Fuzzy
{
    public static class IComparableExtensions {
        public static Fuzzy<T> Between<T>(this Fuzzy<T> fuzzy, T min, T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static Fuzzy<T> GreaterThan<T>(this Fuzzy<T> fuzzy, T min) where T : IComparable<T>
            => throw new NotImplementedException();

        public static Fuzzy<T> LessThan<T>(this Fuzzy<T> fuzzy, T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static Fuzzy<T> Not<T>(this Fuzzy<T> fuzzy, T unexpected) where T : IComparable<T>
            => throw new NotImplementedException();
    }
}
