using Fuzzy;
using Xunit;

namespace Example
{
    public class DoubleExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            double d;
            d = fuzzy.Double();
            d = fuzzy.Double().GreaterThan(.2d);
            d = fuzzy.Double().LessThan(.5d);
            d = fuzzy.Double().Between(.2d, .5d);
            d = fuzzy.Double().Not(.4d);
        }

        [Fact]
        public void GetArray() {
            double[] d = fuzzy.Array(fuzzy.Double);
        }
    }
}
