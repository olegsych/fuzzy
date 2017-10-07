namespace Fuzzy
{
    public class SequentialFuzz : IFuzz
    {
        int current;

        public SequentialFuzz(int seed = default) => current = seed;

        public int Int32() => ++current;
    }
}
