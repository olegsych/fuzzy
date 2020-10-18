using Xunit;

namespace Fuzzy
{
    public class StringExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            string value = fuzzy.String();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void GetFuzzyStringWithLengthConstraint() {
            string value = fuzzy.String(Length.Between(41, 43));
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void GetFuzzyStringWithFormatConstraint() {
            string value;
            value = fuzzy.String().Format("foo{0}");
            value = fuzzy.String(Length.Between(42, 43)).Format("foo{0}");
        }
    }
}
