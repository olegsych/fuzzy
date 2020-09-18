using Xunit;

namespace Fuzzy
{
    public class Int16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            short value = fuzzy.Int16();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            short value;
            value = fuzzy.Int16().Minimum(2);
            value = fuzzy.Int16().Maximum(5);
            value = fuzzy.Int16().Between(2, 5);
        }
    }
}
