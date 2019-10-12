using System;
using Xunit;
using static Fuzzy.Extensions;

namespace Fuzzy
{
    public class DateTimeOffsetScenario
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyDateTimeOffsets() {
            DateTimeOffset first = fuzzy.DateTimeOffset();
            DateTimeOffset second = fuzzy.DateTimeOffset();
            Assert.NotEqual(first, second);
        }

        [Fact]
        public void GetFuzzyDateOfGivenRange() {
            DateTimeOffset date;
            date = fuzzy.DateTimeOffset();
            date = fuzzy.DateTimeOffset().GreaterThan(DateTimeOffset.Now);
            date = fuzzy.DateTimeOffset().LessThan(DateTimeOffset.Now);
            date = fuzzy.DateTimeOffset().Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2));
        }

        [Fact]
        public void MyTestMethod() {
            DateTimeOffset date;
            date = fuzzy.DateTimeOffset();
            date = fuzzy.DateTimeOffset(GreaterThan(DateTimeOffset.Now));
            date = fuzzy.DateTimeOffset(LessThan(DateTimeOffset.Now));
            date = fuzzy.DateTimeOffset(Between(DateTimeOffset.Now, DateTimeOffset.Now + TimeSpan.FromDays(2)));
        }
    }
}
