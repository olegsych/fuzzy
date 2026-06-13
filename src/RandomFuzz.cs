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
        /// <remarks>
        /// The default <paramref name="seed"/> of <c>0</c> produces a deterministic sequence; pass a varying seed for independent runs.
        /// </remarks>
        public RandomFuzz(int seed = 0) => random = new Random(seed);

        /// <inheritdoc cref="IFuzz.Next"/>
        public override int Next() => random.Next();
    }
}
