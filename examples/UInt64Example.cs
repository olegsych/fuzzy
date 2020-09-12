using Xunit;

namespace Fuzzy
{
    public class UInt64Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            ulong value = fuzzy.UInt64();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            ulong value;
            value = fuzzy.UInt64().GreaterThan(2u);
            value = fuzzy.UInt64().LessThan(5u);
            value = fuzzy.UInt64().Between(2u, 5u);
            value = fuzzy.UInt64().Not(4u);
        }
    }
}
