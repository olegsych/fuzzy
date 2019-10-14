using Fuzzy;
using Xunit;

namespace Example
{
    public class ByteExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyBytes() {
            byte b;
            b = fuzzy.Byte();
            b = fuzzy.Byte().GreaterThan(3);
            b = fuzzy.Byte().LessThan(5);
            b = fuzzy.Byte().Between(3, 5);
            b = fuzzy.Byte().Not(4);
        }

        [Fact]
        public void GetArrayOfFuzzyBytes() {
            byte[] bytes = fuzzy.Array(fuzzy.Byte);
        }
    }
}
