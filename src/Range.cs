using System;

namespace Fuzzy
{
    public abstract class Range<TRange> where TRange : Range<TRange>, new()
    {
        int? min;
        int? max;

        public int Maximum => max ?? 13;

        public int Minimum => min ?? 5;

        protected virtual void Initialize(int? min, int? max)
        {
            if (min > max)
                throw new ArgumentException($"Minimum {min} is larger than maximum {max}.");
            this.min = min;
            this.max = max;
        }

        public static TRange Between(int minimum, int maximum)
        {
            var range = new TRange();
            range.Initialize(minimum, maximum);
            return range;
        }

        public static TRange Min(int value)
        {
            var range = new TRange();
            range.Initialize(value, default);
            return range;
        }

        public static TRange Max(int value) => new TRange { max = value };
    }
}
