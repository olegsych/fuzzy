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
            if(min < 0)
                throw new ArgumentOutOfRangeException();
            if(min > max)
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

        public static TRange Exactly(int value) => throw new NotImplementedException();

        public static TRange Min(int min)
        {
            var range = new TRange();
            range.Initialize(min, min + 1);
            return range;
        }

        public static TRange Max(int max)
        {
            var range = new TRange();
            range.Initialize(max - 1, max);
            return range;
        }

        public int New(IFuzz fuzzy) => fuzzy == null
            ? throw new ArgumentNullException(nameof(fuzzy))
            : (int)fuzzy.Int32().Between(Minimum, Maximum);
    }
}
