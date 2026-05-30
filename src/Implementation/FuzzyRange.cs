using System;

namespace Fuzzy.Implementation
{
    /// <summary>
    /// Provides a base class for <see cref="Fuzzy{T}"/> specifications that produce values within an inclusive range.
    /// </summary>
    public abstract class FuzzyRange<T>: Fuzzy<T> where T : struct, IComparable<T>
    {
        T maximum;
        T minimum;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuzzyRange{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzz"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maximum"/> is less than <paramref name="minimum"/>.</exception>
        public FuzzyRange(IFuzz fuzz, T minimum, T maximum) : base(fuzz) {
            if(maximum.CompareTo(minimum) < 0)
                throw new ArgumentOutOfRangeException(nameof(maximum), $"{maximum} is less than the {nameof(minimum)} value {minimum}");
            this.maximum = maximum;
            this.minimum = minimum;
        }

        /// <summary>
        /// Gets or sets the inclusive upper bound of the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The assigned value is less than <see cref="Minimum"/>.</exception>
        public T Maximum {
            get => maximum;
            set {
                if(value.CompareTo(minimum) < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), $"{value} is less than the {nameof(Minimum)} value {minimum}");
                maximum = value;
            }
        }

        /// <summary>
        /// Gets or sets the inclusive lower bound of the range.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The assigned value is greater than <see cref="Maximum"/>.</exception>
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
