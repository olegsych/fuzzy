using System;

namespace Fuzzy
{
    public abstract class Size<TSize> where TSize : Size<TSize>, new()
    {
        const int defaultMinimum = 8;
        const int defaultRange = 5;
        const int defaultMaximum = defaultMinimum + defaultRange;

        int? maximum;
        int? minimum;

        public override bool Equals(object obj) =>
            obj is Size<TSize> otherSize &&
            otherSize.minimum.Equals(minimum) &&
            otherSize.maximum.Equals(maximum);

        public override int GetHashCode() =>
            (minimum, maximum).GetHashCode();

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

        #pragma warning disable CA1000 // Do not declare static members on generic types
        // The following static methods are meant to be invoked on the non-generic child types.

        public static TSize Between(int min, int max)
        {
            var range = new TSize();
            range.Initialize(min, max);
            return range;
        }

        public static TSize Exactly(int value) =>
            Between(value, value);

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

        #pragma warning restore CA1000

        public int Build(IFuzz fuzzy) {
            if(fuzzy == null)
                throw new ArgumentNullException(nameof(fuzzy));
            return fuzzy.Int32().Between(Minimum(), Maximum());
        }

        int Maximum() {
            if(maximum.HasValue)
                return maximum.Value;
            int minimum = Minimum();
            return minimum >= defaultMaximum
                ? minimum + defaultRange
                : defaultMaximum;
        }

        int Minimum() => minimum ?? (
            maximum >= defaultMinimum ? defaultMinimum :
            maximum >= 2 ? 2 :
            maximum ??
            defaultMinimum);
    }
}
