using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class DateTimeOffsetExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<DateTimeOffset> value;
        readonly DateTimeOffset minimum = new DateTimeOffset(DateTimeOffset.MinValue.Ticks + random.Next(), TimeSpan.Zero);
        readonly TimeSpan timeSpan = new TimeSpan(random.Next());

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<DateTimeOffset> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public DateTimeOffsetExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<DateTimeOffset>>(fuzzy, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

        public class Between: DateTimeOffsetExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, timeSpan));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<DateTimeOffset> returned = value.Between(minimum, timeSpan);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(minimum + timeSpan, returned.Maximum);
            }
        }
    }
}
