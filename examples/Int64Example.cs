using Xunit;

namespace Fuzzy
{
    public class Int64Example
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            long value = fuzzy.Int64();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            long value;
            value = fuzzy.Int64().Minimum(42L);
            value = fuzzy.Int64().Maximum(42L);
            value = fuzzy.Int64().Between(41L, 43L);
            value = fuzzy.Int64().Minimum(41L).Maximum(43L);
        }
    }
}
