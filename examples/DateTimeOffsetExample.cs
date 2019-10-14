using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class DateTimeOffsetExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyDateTimeOffsetValues() {
            DateTimeOffset date;
            date = fuzzy.DateTimeOffset();
            date = fuzzy.DateTimeOffset().GreaterThan(DateTimeOffset.Now);
            date = fuzzy.DateTimeOffset().LessThan(DateTimeOffset.Now);
            date = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2));
            date = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, TimeSpan.FromDays(2));
        }

        [Fact]
        public void GetArrayOfFuzzyDateTimes() {
            DateTimeOffset[] dates = fuzzy.Array(fuzzy.DateTimeOffset);
        }
    }
}
