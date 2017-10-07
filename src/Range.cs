using System;

namespace Fuzzy
{
    public abstract class Range<TRange> where TRange : Range<TRange>, new()
    {
        int? min;
        int? max;

        public int Maximum => max ?? 13;

        public int Minimum => min ?? 5;

        public static TRange Between(int minimum, int maximum)
        {
            if (minimum > maximum)
                throw new ArgumentException($"Minimum {minimum} is larger than maximum {maximum}.");
            return new TRange { min = minimum, max = maximum };
        }

        public static TRange Min(int value) => new TRange { min = value};

        public static TRange Max(int value) => new TRange { max = value };
    }
}
