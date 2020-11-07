using System;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class DateTimeOffsetExtensionsTest: TestFixture
    {
        // Method parameters
        readonly DateTimeOffset value = new DateTimeOffset(random.Next(), TimeSpan.Zero);
        readonly DateTimeOffset minimum = new DateTimeOffset(DateTimeOffset.MinValue.Ticks + random.Next(), TimeSpan.Zero);
        readonly TimeSpan timeSpan = new TimeSpan(random.Next());

        // Test fixture
        readonly FuzzyRange<DateTimeOffset> spec;
        readonly DateTimeOffset newValue = new DateTimeOffset(DateTimeOffset.MinValue.Ticks + random.Next(), TimeSpan.Zero);

        public DateTimeOffsetExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<DateTimeOffset>>(fuzzy, DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: DateTimeOffsetExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                DateTimeOffset returned = value.Between(minimum, timeSpan);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(minimum + timeSpan, spec.Maximum);
            }
        }
    }
}
