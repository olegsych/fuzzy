namespace Fuzzy
{
    /// <summary>
    /// Produces fuzzy test values from a predictable sequence of integers.
    /// </summary>
    public class SequentialFuzz : Implementation.Fuzz
    {
        int current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialFuzz"/> class.
        /// </summary>
        /// <param name="seed">The value preceding the first integer returned by <see cref="Next"/>.</param>
        public SequentialFuzz(int seed = default) => current = seed;

        /// <summary>
        /// Returns the next integer in the predictable sequence, incremented by one on each call.
        /// </summary>
        public override int Next() => ++current;
    }
}
