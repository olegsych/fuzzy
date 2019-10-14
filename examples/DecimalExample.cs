using Fuzzy;
using Xunit;

namespace Example
{
    public class DecimalExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            decimal d;
            d = fuzzy.Decimal();
            d = fuzzy.Decimal().GreaterThan(2m);
            d = fuzzy.Decimal().LessThan(5m);
            d = fuzzy.Decimal().Between(2m, 5m);
            d = fuzzy.Decimal().Not(4m);
        }

        [Fact]
        public void GetArray() {
            decimal[] d = fuzzy.Array(fuzzy.Decimal);
        }
    }
}
