using Xunit;

namespace Fuzzy
{
    public class UInt32Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            uint value = fuzzy.UInt32();
        }

        [Fact]
        public void GetArrayOfFuzzyValues() {
            uint[] values = fuzzy.Array(fuzzy.UInt32);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            uint value;
            value = fuzzy.UInt32().GreaterThan(2u);
            value = fuzzy.UInt32().LessThan(5u);
            value = fuzzy.UInt32().Between(2u, 5u);
            value = fuzzy.UInt32().Not(4u);
        }
    }
}
