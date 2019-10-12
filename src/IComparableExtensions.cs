using System;

namespace Fuzzy
{
    public static class IComparableExtensions
    {
        public static T Between<T>(this T fuzzy, T min, T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static T GreaterThan<T>(this T fuzzy, T min) where T : IComparable<T>
            => throw new NotImplementedException();

        public static T LessThan<T>(this T fuzzy, T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static T Not<T>(this T fuzzy, T unexpected) where T : IComparable<T>
            => throw new NotImplementedException();
    }
}
