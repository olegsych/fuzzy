using Xunit;

namespace Fuzzy
{
    public class SByteExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            sbyte value = fuzzy.SByte();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            sbyte value;
            value = fuzzy.SByte().GreaterThan(3);
            value = fuzzy.SByte().LessThan(5);
            value = fuzzy.SByte().Between(3, 5);
            value = fuzzy.SByte().Not(4);
        }
    }
}
