namespace Fuzzy
{
    /// <summary>
    /// Produces fuzzy test values from a monotonically increasing sequence of integers.
    /// </summary>
    public class SequentialFuzz : Implementation.Fuzz
    {
        int current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialFuzz"/> class.
        /// </summary>
        /// <param name="seed">The value preceding the first integer returned by <see cref="Next"/>.</param>
        public SequentialFuzz(int seed = default) => current = seed;

        /// <inheritdoc/>
        public override int Next() => ++current;
    }
}
