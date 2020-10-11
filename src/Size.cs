using System;

namespace Fuzzy
{
    public abstract class Size<TSize> where TSize : Size<TSize>, new()
    {
        int? maximum;
        int? minimum;

        protected virtual void Initialize(int? min, int? max)
        {
            if(min < 0)
                throw new ArgumentOutOfRangeException(nameof(min));
            if(max < 0)
                throw new ArgumentOutOfRangeException(nameof(max));
            if(max < min)
                throw new ArgumentException($"Minimum {min} is larger than maximum {max}.", nameof(max));
            minimum = min;
            maximum = max;
        }

        public static TSize Between(int min, int max)
        {
            var range = new TSize();
            range.Initialize(min, max);
            return range;
        }

        public static TSize Exactly(int value) => throw new NotImplementedException();

        public static TSize Min(int min)
        {
            var range = new TSize();
            range.Initialize(min, null);
            return range;
        }

        public static TSize Max(int max)
        {
            var range = new TSize();
            range.Initialize(null, max);
            return range;
        }

        public FuzzyRange<int> New(IFuzz fuzzy) {
            if(fuzzy == null)
                throw new ArgumentNullException(nameof(fuzzy));
            int minimum = this.minimum ?? 0;
            int maximum = this.maximum ?? int.MaxValue;
            return fuzzy.Int32().Between(minimum, maximum);
        }
    }
}
