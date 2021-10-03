namespace Fuzzy
{
    public class SequentialFuzz : Implementation.Fuzz
    {
        int current;

        public SequentialFuzz(int seed = default) => current = seed;

        public override int Number() => ++current;
    }
}
