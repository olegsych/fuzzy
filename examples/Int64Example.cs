using Fuzzy;
using Xunit;

namespace Example
{
    public class Int64Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            long number;
            number = fuzzy.Int64();
            number = fuzzy.Int64().LessThan(42L);
            number = fuzzy.Int64().GreaterThan(42L);
            number = fuzzy.Int64().Between(41L, 43L);
            number = fuzzy.Int64().GreaterThan(41L).LessThan(43L);
            number = fuzzy.Int64().Not(42L);
        }

        [Fact]
        public void GetArray() {
            long[] numbers = fuzzy.Array(fuzzy.Int64);
        }
    }
}
