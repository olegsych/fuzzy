using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class ElementExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            IEnumerable<int> candidates = new[] { 41, 42, 43 };
            int value = fuzzy.Element(candidates);
        }
    }
}
