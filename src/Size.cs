using System;

namespace Fuzzy
{
    public abstract class Size<TSize> where TSize : Size<TSize>, new()
    {
        public int? Maximum { get; private set; }

        public int? Minimum { get; private set; }

        protected virtual void Initialize(int? min, int? max)
        {
            if(min < 0)
                throw new ArgumentOutOfRangeException();
            if(min > max)
                throw new ArgumentException($"Minimum {min} is larger than maximum {max}.");
            Minimum = min;
            Maximum = max;
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
            range.Initialize(min, null);
            return range;
        }

        public static TSize Max(int max)
        {
            var range = new TSize();
            range.Initialize(null, max);
            return range;
        }

        public int New(IFuzz fuzzy) {
            if(fuzzy == null)
                throw new ArgumentNullException(nameof(fuzzy));
            return fuzzy.Int32().Between(Minimum.Value, Maximum.Value);
        }
    }
}
