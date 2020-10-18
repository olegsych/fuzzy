using System;
using Xunit;

namespace Fuzzy
{
    public class UriExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            Uri value = fuzzy.Uri();
        }
    }
}
