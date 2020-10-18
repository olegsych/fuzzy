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

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            float value;
            value = fuzzy.Single().GreaterThan(.2f);
            value = fuzzy.Single().LessThan(.5f);
            value = fuzzy.Single().Between(.2f, .5f);
            value = fuzzy.Single().Not(.4f);
        }
    }
}
