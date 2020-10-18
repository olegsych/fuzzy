using Xunit;

namespace Fuzzy
{
    public class UInt64Example
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            ulong value = fuzzy.UInt64();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            ulong value;
            value = fuzzy.UInt64().Maximum(2u);
            value = fuzzy.UInt64().Minimum(5u);
            value = fuzzy.UInt64().Between(2u, 5u);
        }
    }
}
