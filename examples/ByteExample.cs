using Xunit;

namespace Fuzzy
{
    public class ByteExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            byte value = fuzzy.Byte();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            byte value;
            value = fuzzy.Byte().GreaterThan(3);
            value = fuzzy.Byte().LessThan(5);
            value = fuzzy.Byte().Between(3, 5);
            value = fuzzy.Byte().Not(4);
        }
    }
}
