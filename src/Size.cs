using System;

namespace Fuzzy
{
    /// <summary>Specifies an inclusive range of non-negative integer sizes for fuzzy values.</summary>
    /// <remarks>
    /// When a bound is left unspecified, <see cref="Build"/> derives it from the specified bound and a default range of 5,
    /// falling back to <c>[8, 13]</c> when neither bound is specified.
    /// </remarks>
    /// <typeparam name="TSize">The derived size type, per the curiously recurring template pattern.</typeparam>
    public abstract class Size<TSize> where TSize : Size<TSize>, new()
    {
        const int defaultMinimum = 8;
        const int defaultRange = 5;
        const int defaultMaximum = defaultMinimum + defaultRange;

        int? maximum;
        int? minimum;

        /// <inheritdoc/>
        public override bool Equals(object other) =>
            other is Size<TSize> otherSize &&
            otherSize.minimum.Equals(minimum) &&
            otherSize.maximum.Equals(maximum);

        /// <inheritdoc/>
        public override int GetHashCode() =>
            (minimum, maximum).GetHashCode();

        /// <summary>Sets the inclusive minimum and maximum bounds of this size.</summary>
        /// <param name="min">The inclusive lower bound, or <see langword="null"/> for unbounded.</param>
        /// <param name="max">The inclusive upper bound, or <see langword="null"/> for unbounded.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> or <paramref name="max"/> is negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/>.</exception>
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

        /// <summary>Returns a <typeparamref name="TSize"/> bounded inclusively by <paramref name="min"/> and <paramref name="max"/>.</summary>
        /// <param name="min">The inclusive lower bound.</param>
        /// <param name="max">The inclusive upper bound.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> or <paramref name="max"/> is negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/>.</exception>
        public static TSize Between(int min, int max)
        {
            var range = new TSize();
            range.Initialize(min, max);
            return range;
        }

        /// <summary>Returns a <typeparamref name="TSize"/> bounded inclusively to a single <paramref name="value"/>.</summary>
        /// <param name="value">The inclusive bound.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is negative.</exception>
        public static TSize Exactly(int value) =>
            Between(value, value);

        /// <summary>Returns a <typeparamref name="TSize"/> with an inclusive lower bound of <paramref name="min"/> and no explicit upper bound.</summary>
        /// <param name="min">The inclusive lower bound.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> is negative.</exception>
        public static TSize Min(int min)
        {
            var range = new TSize();
            range.Initialize(min, null);
            return range;
        }

        /// <summary>Returns a <typeparamref name="TSize"/> with no explicit lower bound and an inclusive upper bound of <paramref name="max"/>.</summary>
        /// <param name="max">The inclusive upper bound.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is negative.</exception>
        public static TSize Max(int max)
        {
            var range = new TSize();
            range.Initialize(null, max);
            return range;
        }

        /// <summary>Returns a fuzzy size within the configured bounds.</summary>
        /// <param name="fuzzy">The <see cref="IFuzz"/> instance used to generate the value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
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
