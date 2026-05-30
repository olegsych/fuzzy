using System;

namespace Fuzzy
{
    /// <summary>
    /// Produces fuzzy test values from a pseudo-random sequence.
    /// </summary>
    public class RandomFuzz : Implementation.Fuzz
    {
        readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomFuzz"/> class.
        /// </summary>
        /// <param name="seed">A seed for the underlying <see cref="Random"/>, enabling reproducible sequences.</param>
        public RandomFuzz(int seed = 0) => random = new Random(seed);

        /// <inheritdoc/>
        public override int Next() => random.Next();
    }
}
