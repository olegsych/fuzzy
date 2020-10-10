using System;

namespace Fuzzy
{
    public abstract class Size<TSize> where TSize : Size<TSize>, new()
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

        public static TSize Between(int minimum, int maximum)
        {
            var range = new TSize();
            range.Initialize(minimum, maximum);
            return range;
        }

        public static TSize Exactly(int value) => throw new NotImplementedException();

        public static TSize Min(int min)
        {
            var range = new TSize();
            range.Initialize(min, min + 1);
            return range;
        }

        public static TSize Max(int max)
        {
            var range = new TSize();
            range.Initialize(max - 1, max);
            return range;
        }

        public int New(IFuzz fuzzy) {
            if(fuzzy == null)
                throw new ArgumentNullException(nameof(fuzzy));
            return fuzzy.Int32().Between(Minimum, Maximum);
        }
    }
}
