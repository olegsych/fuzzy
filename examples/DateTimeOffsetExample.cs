using System;
using Xunit;

namespace Fuzzy
{
    public class DateTimeOffsetExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyDateTimeOffsetValues() {
            DateTimeOffset value = fuzzy.DateTimeOffset();
        }

        [Fact]
        public void GetArrayOfFuzzyDateTimes() {
            DateTimeOffset[] values = fuzzy.Array(fuzzy.DateTimeOffset);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValues() {
            DateTimeOffset value;
            value = fuzzy.DateTimeOffset().GreaterThan(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().LessThan(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2));
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, TimeSpan.FromDays(2));
        }
    }
}
