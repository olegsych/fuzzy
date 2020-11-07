using System;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class DateTimeExtensionsTest: TestFixture
    {
        // Method parameters
        readonly DateTime value = new DateTime(random.Next());
        readonly DateTime minimum = new DateTime(DateTime.MinValue.Ticks + random.Next());
        readonly TimeSpan timeSpan = new TimeSpan(random.Next());

        // Test fixture
        readonly FuzzyRange<DateTime> spec;
        readonly DateTime newValue = new DateTime(DateTime.MinValue.Ticks + random.Next());

        public DateTimeExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<DateTime>>(fuzzy, DateTime.MinValue, DateTime.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: DateTimeExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                DateTime returned = value.Between(minimum, timeSpan);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(minimum + timeSpan, spec.Maximum);
            }
        }
    }
}
