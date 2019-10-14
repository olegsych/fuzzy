using Fuzzy;
using Xunit;

namespace Example
{
    public class CharExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyChars() {
            char c;
            c = fuzzy.Char();
            c = fuzzy.Char().GreaterThan('a');
            c = fuzzy.Char().LessThan('f');
            c = fuzzy.Char().Between('a', 'f');
            c = fuzzy.Char().Not('c');
        }

        [Fact]
        public void GetArrayOfFuzzyChars() {
            char[] chars = fuzzy.Array(fuzzy.Char);
        }
    }
}
