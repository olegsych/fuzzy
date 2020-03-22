using System;

namespace Fuzzy
{
    public class SequentialFuzz : IFuzz
    {
        int current;

        public SequentialFuzz(int seed = default) => current = seed;

        public int Next() => throw new NotImplementedException();
    }
}
