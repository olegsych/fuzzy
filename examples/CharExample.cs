using Xunit;

namespace Fuzzy
{
    public class CharExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            char value = fuzzy.Char();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            char value;
            value = fuzzy.Char().Minimum('a');
            value = fuzzy.Char().Maximum('f');
            value = fuzzy.Char().Between('a', 'f');
        }
    }
}
