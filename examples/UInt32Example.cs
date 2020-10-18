using Xunit;

namespace Fuzzy
{
    public class UInt32Example
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            uint value = fuzzy.UInt32();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            uint value;
            value = fuzzy.UInt32().Maximum(2u);
            value = fuzzy.UInt32().Minimum(5u);
            value = fuzzy.UInt32().Between(2u, 5u);
        }
    }
}
