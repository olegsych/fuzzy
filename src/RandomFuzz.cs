using System;

#pragma warning disable CA5394 // Do not use insecure randomness
// Random numbers are used for testing only.

namespace Fuzzy
{
    public class RandomFuzz : Implementation.Fuzz
    {
        readonly Random random;

        public RandomFuzz(int seed = 0) => random = new Random(seed);

        public override int Number() => random.Next();
    }
}
