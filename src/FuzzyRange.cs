using System;

namespace Fuzzy
{
    public abstract class FuzzyRange<T>: Fuzzy<T> where T : struct, IComparable<T>
    {
        T maximum;
        T minimum;

        public FuzzyRange(IFuzz fuzz, T minimum, T maximum) : base(fuzz) {
            if(maximum.CompareTo(minimum) < 0)
                throw new ArgumentOutOfRangeException(nameof(maximum), $"{maximum} is less than the {nameof(minimum)} value {minimum}");
            this.maximum = maximum;
            this.minimum = minimum;
        }

        public T Maximum {
            get => maximum;
            set {
                if(value.CompareTo(minimum) < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"{value} is less than the {nameof(Minimum)} value {minimum}");
                maximum = value;
            }
        }

        public T Minimum {
            get => minimum;
            set {
                if(value.CompareTo(maximum) > 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"{value} is greater than the {nameof(Maximum)} value {maximum}");
                minimum = value;
            }
        }
    }
}
