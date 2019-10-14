using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class DateTimeExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyDateTime() {
            DateTime date;
            date = fuzzy.DateTime();
            date = fuzzy.DateTime().GreaterThan(DateTime.Now);
            date = fuzzy.DateTime().LessThan(DateTime.Now);
            date = fuzzy.DateTime().Between(DateTime.Now, DateTime.Now + TimeSpan.FromDays(2));
            date = fuzzy.DateTime().Between(DateTime.Now, TimeSpan.FromDays(2));
        }

        [Fact]
        public void GetArrayOfFuzzyDateTimes() {
            DateTime[] dates = fuzzy.Array(fuzzy.DateTime);
        }
    }
}
