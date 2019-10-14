using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class TimeSpanExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            TimeSpan d;
            d = fuzzy.TimeSpan();
            d = fuzzy.TimeSpan().GreaterThan(TimeSpan.FromMinutes(2));
            d = fuzzy.TimeSpan().LessThan(TimeSpan.FromMinutes(5));
            d = fuzzy.TimeSpan().Between(TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(5));
            d = fuzzy.TimeSpan().Not(TimeSpan.FromMinutes(2));
        }

        [Fact]
        public void GetArray() {
            TimeSpan[] d = fuzzy.Array(fuzzy.TimeSpan);
        }
    }
}
