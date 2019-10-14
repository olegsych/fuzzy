using Fuzzy;
using Xunit;

namespace Example
{
    public class UInt16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            ushort d;
            d = fuzzy.UInt16();
            d = fuzzy.UInt16().GreaterThan(2);
            d = fuzzy.UInt16().LessThan(5);
            d = fuzzy.UInt16().Between(2, 5);
            d = fuzzy.UInt16().Not(4);
        }

        [Fact]
        public void GetArray() {
            ushort[] d = fuzzy.Array(fuzzy.UInt16);
        }
    }
}
