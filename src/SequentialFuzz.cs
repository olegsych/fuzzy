using System;

namespace Fuzzy
{
    public class SequentialFuzz : IFuzz
    {
        int current;

        public SequentialFuzz(int seed = default) => current = seed;

        public T GetValue<T>(Fuzzy<T> fuzzy) {
            throw new NotImplementedException();
        }

        public int Next() => ++current;
    }
}
