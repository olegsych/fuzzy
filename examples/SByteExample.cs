using Xunit;

namespace Fuzzy
{
    public class SByteExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            sbyte value = fuzzy.SByte();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            sbyte value;
            value = fuzzy.SByte().Minimum(3);
            value = fuzzy.SByte().Maximum(5);
            value = fuzzy.SByte().Between(3, 5);
        }
    }
}
