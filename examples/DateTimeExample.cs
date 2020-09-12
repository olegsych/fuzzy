using System;
using Xunit;

namespace Fuzzy
{
    public class DateTimeExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetFuzzyDateTime() {
            DateTime date = fuzzy.DateTime();
        }

        [Fact]
        public void GetArrayOfFuzzyDateTimes() {
            DateTime[] values = fuzzy.Array(fuzzy.DateTime);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ConstrainFuzzyValue() {
            DateTime value;
            value = fuzzy.DateTime().GreaterThan(DateTime.Now);
            value = fuzzy.DateTime().LessThan(DateTime.Now);
            value = fuzzy.DateTime().Between(DateTime.Now, DateTime.Now + TimeSpan.FromDays(2));
            value = fuzzy.DateTime().Between(DateTime.Now, TimeSpan.FromDays(2));
        }
    }
}
