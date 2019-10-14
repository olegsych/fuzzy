using System;

namespace Fuzzy
{
    public class RandomFuzz : IFuzz
    {
        readonly Random random;

        public RandomFuzz(int seed = 0) => random = new Random(seed);

        public Fuzzy<int> Int32() => throw new NotImplementedException();
    }
}
