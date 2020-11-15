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
    }
}
