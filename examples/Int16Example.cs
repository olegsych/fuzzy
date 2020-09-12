using Xunit;

namespace Fuzzy
{
    public class Int16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            short value = fuzzy.Int16();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            short value;
            value = fuzzy.Int16().GreaterThan(2);
            value = fuzzy.Int16().LessThan(5);
            value = fuzzy.Int16().Between(2, 5);
            value = fuzzy.Int16().Not(4);
        }
    }
}
