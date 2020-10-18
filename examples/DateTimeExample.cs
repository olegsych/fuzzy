using System;
using Xunit;

namespace Fuzzy
{
    public class DateTimeExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            DateTime date = fuzzy.DateTime();
        }

        [Fact]
        public void ConstrainFuzzyValue() {
            DateTime value;
            value = fuzzy.DateTime().Minimum(DateTime.Now);
            value = fuzzy.DateTime().Maximum(DateTime.Now);
            value = fuzzy.DateTime().Between(DateTime.Now, DateTime.Now + TimeSpan.FromDays(2));
            value = fuzzy.DateTime().Between(DateTime.Now, TimeSpan.FromDays(2));
        }
    }
}
