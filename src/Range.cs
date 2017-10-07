using System;

namespace Fuzzy
{
    public struct Range
    {
        readonly int? min;
        readonly int? max;

        Range(int? min, int? max)
        {
            this.min = min;
            this.max = max;
        }

        public int Maximum => max ?? 13;

        public int Minimum => min ?? 5;

        public static Range Between(int min, int max)
        {
            if (min > max)
                throw new ArgumentException($"Minimum {min} is larger than maximum {max}.");
            return new Range(min, max);
        }

        public static Range Min(int min) => new Range(min, default);

        public static Range Max(int max) => new Range(default, max);
    }
}
