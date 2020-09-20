using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class DateTimeExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<DateTime> value;
        readonly DateTime minimum = new DateTime(DateTime.MinValue.Ticks + random.Next());
        readonly TimeSpan timeSpan = new TimeSpan(random.Next());

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<DateTime> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public DateTimeExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<DateTime>>(fuzzy, DateTime.MinValue, DateTime.MaxValue);

        public class Between: DateTimeExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, timeSpan));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<DateTime> returned = value.Between(minimum, timeSpan);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(minimum + timeSpan, returned.Maximum);
            }
        }
    }
}
