using Xunit;

namespace Fuzzy
{
    public class Int32Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            int number = fuzzy.Int32();
        }

        [Fact]
        public void GetArray() {
            int[] numbers = fuzzy.Array(fuzzy.Int32);
        }

        [Fact(Skip = "Not Implemented")]
        public void GetValueFromGivenRange() {
            int number;
            number = fuzzy.Int32().LessThan(42);
            number = fuzzy.Int32().GreaterThan(42);
            number = fuzzy.Int32().Between(41, 43);
            number = fuzzy.Int32().GreaterThan(41).LessThan(43);
            number = fuzzy.Int32().Not(42);
        }
    }
}
