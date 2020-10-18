using System;
using Xunit;

namespace Fuzzy
{
    public class DateTimeOffsetExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            DateTimeOffset value = fuzzy.DateTimeOffset();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            DateTimeOffset value;
            value = fuzzy.DateTimeOffset().Minimum(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().Maximum(DateTimeOffset.Now);
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2));
            value = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, TimeSpan.FromDays(2));
        }
    }
}
