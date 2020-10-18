using Xunit;

namespace Fuzzy
{
    public class DoubleExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            double d = fuzzy.Double();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            double value;
            value = fuzzy.Double().GreaterThan(.2d);
            value = fuzzy.Double().LessThan(.5d);
            value = fuzzy.Double().Between(.2d, .5d);
            value = fuzzy.Double().Not(.4d);
        }
    }
}
