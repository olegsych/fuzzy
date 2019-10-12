using Xunit;

namespace Fuzzy
{
    public class Int32Scenario
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyIntegers() {
            int number;
            number = fuzzy.Int32();
            number = fuzzy.Int32().LessThan(42);
            number = fuzzy.Int32().GreaterThan(42);
            number = fuzzy.Int32().Between(41, 43);
            number = fuzzy.Int32().GreaterThan(41).LessThan(43);
            number = fuzzy.Int32().Not(42);
        }
    }
}
