namespace Fuzzy
{
    public class SequentialFuzz : IFuzz
    {
        int seed;

        public SequentialFuzz(int seed = default) => this.seed = seed;

        public int Int32() => ++seed;
    }
}
