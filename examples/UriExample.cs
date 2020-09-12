using System;
using Xunit;

namespace Fuzzy
{
    public class UriExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            Uri value = fuzzy.Uri();
        }

        [Fact]
        public void GetArrayOfFuzzyValues() {
            Uri[] s = fuzzy.Array(fuzzy.Uri);
        }
    }
}
