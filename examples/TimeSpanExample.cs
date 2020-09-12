using System;
using Xunit;

namespace Fuzzy
{
    public class TimeSpanExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            TimeSpan value = fuzzy.TimeSpan();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            TimeSpan value;
            value = fuzzy.TimeSpan().GreaterThan(TimeSpan.FromMinutes(2));
            value = fuzzy.TimeSpan().LessThan(TimeSpan.FromMinutes(5));
            value = fuzzy.TimeSpan().Between(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(5));
            value = fuzzy.TimeSpan().Not(TimeSpan.FromMinutes(2));
        }
    }
}
