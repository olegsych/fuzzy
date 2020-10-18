using System;
using Xunit;

namespace Fuzzy
{
    public class TimeSpanExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            TimeSpan value = fuzzy.TimeSpan();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            TimeSpan value;
            value = fuzzy.TimeSpan().Minimum(TimeSpan.FromMinutes(2));
            value = fuzzy.TimeSpan().Maximum(TimeSpan.FromMinutes(5));
            value = fuzzy.TimeSpan().Between(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(5));
        }
    }
}
