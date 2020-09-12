using Xunit;

namespace Fuzzy
{
    public class UInt16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            ushort value = fuzzy.UInt16();
        }

        [Fact]
        public void GetArray() {
            ushort[] values = fuzzy.Array(fuzzy.UInt16);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            ushort value;
            value = fuzzy.UInt16().GreaterThan(2);
            value = fuzzy.UInt16().LessThan(5);
            value = fuzzy.UInt16().Between(2, 5);
            value = fuzzy.UInt16().Not(4);
        }
    }
}
