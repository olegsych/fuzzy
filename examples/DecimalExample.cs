using Xunit;

namespace Fuzzy
{
    public class DecimalExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            decimal value = fuzzy.Decimal();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            decimal value;
            value = fuzzy.Decimal().GreaterThan(2m);
            value = fuzzy.Decimal().LessThan(5m);
            value = fuzzy.Decimal().Between(2m, 5m);
            value = fuzzy.Decimal().Not(4m);
        }
    }
}
