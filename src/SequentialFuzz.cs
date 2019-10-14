using System;

namespace Fuzzy
{
    public class SequentialFuzz : IFuzz
    {
        int current;

        public SequentialFuzz(int seed = default) => current = seed;

        public Fuzzy<int> Int32() => throw new NotImplementedException();
    }
}
