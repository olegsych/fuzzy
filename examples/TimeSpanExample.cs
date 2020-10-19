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
            value = fuzzy.TimeSpan().Ticks();
            value = fuzzy.TimeSpan().Milliseconds();
            value = fuzzy.TimeSpan().Seconds();
            value = fuzzy.TimeSpan().Minutes();
            value = fuzzy.TimeSpan().Hours();
            value = fuzzy.TimeSpan().Days();
            value = fuzzy.TimeSpan().Minimum(TimeSpan.FromMinutes(2));
            value = fuzzy.TimeSpan().Maximum(TimeSpan.FromMinutes(5));
            value = fuzzy.TimeSpan().Between(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(5));
        }
    }
}
