using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class IndexExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            IEnumerable<string> elements = new[] { "foo", "bar", "baz" };
            int value = fuzzy.Index(elements);
        }
    }
}
