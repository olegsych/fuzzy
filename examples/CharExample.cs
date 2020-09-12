using Xunit;

namespace Fuzzy
{
    public class CharExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyChars() {
            char value = fuzzy.Char();
        }

        [Fact]
        public void GetArrayOfFuzzyChars() {
            char[] values = fuzzy.Array(fuzzy.Char);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            char value;
            value = fuzzy.Char().GreaterThan('a');
            value = fuzzy.Char().LessThan('f');
            value = fuzzy.Char().Between('a', 'f');
            value = fuzzy.Char().Not('c');
        }
    }
}
