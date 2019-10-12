using System;

namespace Fuzzy
{
    public static class Extensions
    {
        public static IBuilder<T> Between<T>(T min, T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static IBuilder<T> GreaterThan<T>(T min) where T : IComparable<T>
            => throw new NotImplementedException();

        public static IBuilder<T> LessThan<T>(T max) where T : IComparable<T>
            => throw new NotImplementedException();

        public static IBuilder<T> Not<T>(T unexpected) where T : IComparable<T>
            => throw new NotImplementedException();

        public static IBuilder<string> Format(string format)
            => throw new NotImplementedException();
    }
}
