using Xunit;

namespace Fuzzy
{
    public class BooleanExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            bool value = fuzzy.Boolean();
        }
    }
}
