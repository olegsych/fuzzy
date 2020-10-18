using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class ElementExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            IEnumerable<string> candidates = new[] { "foo", "bar", "baz" };
            string value = fuzzy.Element(candidates);
        }
    }
}
