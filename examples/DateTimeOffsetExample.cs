using System;
using Xunit;

namespace Fuzzy
{
    public class DateTimeOffsetExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyValue() {
            DateTimeOffset value = fuzzy.DateTimeOffset();
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            DateTimeOffset value;
            value = fuzzy.DateTimeOffset().GreaterThan(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().LessThan(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2));
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, TimeSpan.FromDays(2));
        }
    }
}
