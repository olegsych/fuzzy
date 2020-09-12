using Xunit;

namespace Fuzzy
{
    public class Int32Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            int value = fuzzy.Int32();
        }

        [Fact(Skip = "Not Implemented")]
        public void ConstrainFuzzyValue() {
            int value;
            value = fuzzy.Int32().LessThan(42);
            value = fuzzy.Int32().GreaterThan(42);
            value = fuzzy.Int32().Between(41, 43);
            value = fuzzy.Int32().GreaterThan(41).LessThan(43);
            value = fuzzy.Int32().Not(42);
        }
    }
}
