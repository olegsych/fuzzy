using Xunit;

namespace Fuzzy
{
    public class UInt16Example
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            ushort value = fuzzy.UInt16();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            ushort value;
            value = fuzzy.UInt16().Minimum(2);
            value = fuzzy.UInt16().Maximum(5);
            value = fuzzy.UInt16().Between(2, 5);
        }
    }
}
