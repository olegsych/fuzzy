using Fuzzy;
using Xunit;

namespace Example
{
    public class UInt64Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            ulong d;
            d = fuzzy.UInt64();
            d = fuzzy.UInt64().GreaterThan(2u);
            d = fuzzy.UInt64().LessThan(5u);
            d = fuzzy.UInt64().Between(2u, 5u);
            d = fuzzy.UInt64().Not(4u);
        }

        [Fact]
        public void GetArray() {
            ulong[] d = fuzzy.Array(fuzzy.UInt64);
        }
    }
}
