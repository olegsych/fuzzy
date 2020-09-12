using Xunit;

namespace Fuzzy
{
    public class Int64Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            long value = fuzzy.Int64();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            long value;
            value = fuzzy.Int64().LessThan(42L);
            value = fuzzy.Int64().GreaterThan(42L);
            value = fuzzy.Int64().Between(41L, 43L);
            value = fuzzy.Int64().GreaterThan(41L).LessThan(43L);
            value = fuzzy.Int64().Not(42L);
        }
    }
}
