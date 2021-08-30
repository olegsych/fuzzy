using System;

namespace Fuzzy
{
    public class RandomFuzz : Implementation.Fuzz
    {
        readonly Random random;

        public RandomFuzz(int seed = 0) => random = new Random(seed);

        public override int Number() => random.Next();
    }
}
