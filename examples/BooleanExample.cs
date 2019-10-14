using Fuzzy;
using Xunit;

namespace Example
{
    public class BooleanExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyBoolean() {
            bool b = fuzzy.Boolean();
        }

        [Fact]
        public void GetArrayOfFuzzyBooleanValues() {
            bool[] bs = fuzzy.Array(fuzzy.Boolean);
        }
    }
}
