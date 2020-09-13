using System;

namespace Fuzzy
{
    public class RandomFuzz : IFuzz
    {
        readonly Random random;

        public RandomFuzz(int seed = 0) => random = new Random(seed);

        public T GetValue<T>(Fuzzy<T> fuzzy) {
            throw new NotImplementedException();
        }

        public int Next() => random.Next();
    }
}
