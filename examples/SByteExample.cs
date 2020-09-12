using Xunit;

namespace Fuzzy
{
    public class SByteExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            sbyte b;
            b = fuzzy.SByte();
            b = fuzzy.SByte().GreaterThan(3);
            b = fuzzy.SByte().LessThan(5);
            b = fuzzy.SByte().Between(3, 5);
            b = fuzzy.SByte().Not(4);
        }

        [Fact]
        public void GetArray() {
            sbyte[] bytes = fuzzy.Array(fuzzy.SByte);
        }
    }
}
