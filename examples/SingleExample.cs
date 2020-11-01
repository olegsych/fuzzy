using Xunit;

namespace Fuzzy
{
    public class SingleExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            float value = fuzzy.Single();
        }
    }
}
