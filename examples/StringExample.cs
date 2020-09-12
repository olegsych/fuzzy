using Xunit;

namespace Fuzzy
{
    public class StringExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            string value = fuzzy.String();
        }

        [Fact]
        public void GetArrayOfFuzzyValues() {
            string[] values = fuzzy.Array(fuzzy.String);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            string value;
            value = fuzzy.String(Length.Between(41, 43));
            value = fuzzy.String().Format("foo{0}");
            value = fuzzy.String(Length.Between(42, 43)).Format("foo{0}");
        }
    }
}
