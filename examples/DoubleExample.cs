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
    }
}
