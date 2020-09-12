using Xunit;

namespace Fuzzy
{
    public class BooleanExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyBoolean() {
            bool value = fuzzy.Boolean();
        }

        [Fact]
        public void GetArrayOfFuzzyBooleanValues() {
            bool[] values = fuzzy.Array(fuzzy.Boolean);
        }
    }
}
