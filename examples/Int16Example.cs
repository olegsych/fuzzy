using Xunit;

namespace Fuzzy
{
    public class Int16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            short d;
            d = fuzzy.Int16();
            d = fuzzy.Int16().GreaterThan(2);
            d = fuzzy.Int16().LessThan(5);
            d = fuzzy.Int16().Between(2, 5);
            d = fuzzy.Int16().Not(4);
        }

        [Fact]
        public void GetArray() {
            short[] d = fuzzy.Array(fuzzy.Int16);
        }
    }
}
