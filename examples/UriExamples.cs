using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class UriExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            Uri s = fuzzy.Uri();
        }

        [Fact]
        public void GetArray() {
            Uri[] s = fuzzy.Array(fuzzy.Uri);
        }
    }
}
