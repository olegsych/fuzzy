using Fuzzy;
using Xunit;

namespace Example
{
    public class SingleExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            float d;
            d = fuzzy.Single();
            d = fuzzy.Single().GreaterThan(.2f);
            d = fuzzy.Single().LessThan(.5f);
            d = fuzzy.Single().Between(.2f, .5f);
            d = fuzzy.Single().Not(.4f);
        }

        [Fact]
        public void GetArray() {
            float[] d = fuzzy.Array(fuzzy.Single);
        }
    }
}
