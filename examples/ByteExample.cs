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

        [Fact]
        public void ConstrainFuzzyValue() {
            byte value;
            value = fuzzy.Byte().Minimum(3);
            value = fuzzy.Byte().Maximum(5);
            value = fuzzy.Byte().Between(3, 5);
        }
    }
}
