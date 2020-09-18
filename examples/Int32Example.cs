using Xunit;

namespace Fuzzy
{
    public class Int32Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            int value = fuzzy.Int32();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            int value;
            value = fuzzy.Int32().Maximum(42);
            value = fuzzy.Int32().Minimum(42);
            value = fuzzy.Int32().Between(41, 43);
            value = fuzzy.Int32().Minimum(41).Maximum(43);
        }
    }
}
