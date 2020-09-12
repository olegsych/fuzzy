using Xunit;

namespace Fuzzy
{
    public class UInt32Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            uint d;
            d = fuzzy.UInt32();
            d = fuzzy.UInt32().GreaterThan(2u);
            d = fuzzy.UInt32().LessThan(5u);
            d = fuzzy.UInt32().Between(2u, 5u);
            d = fuzzy.UInt32().Not(4u);
        }

        [Fact]
        public void GetArray() {
            uint[] d = fuzzy.Array(fuzzy.UInt32);
        }
    }
}
