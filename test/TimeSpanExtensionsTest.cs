using System;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class TimeSpanExtensionsTest: TestFixture
    {
        // Method parameters
        readonly TimeSpan value = new TimeSpan(random.Next());

        // Test fixture
        readonly FuzzyRange<TimeSpan> spec;
        readonly TimeSpan newValue = new TimeSpan(random.Next());

        public TimeSpanExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<TimeSpan>>(fuzzy, TimeSpan.MinValue, TimeSpan.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Ticks: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToTicks() {
                TimeSpan returned = value.Ticks();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(1), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMillisecond - 1), spec.Maximum);
            }
        }

        public class Milliseconds: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToMilliseconds() {
                TimeSpan returned = value.Milliseconds();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMillisecond), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerSecond - 1), spec.Maximum);
            }
        }

        public class Seconds: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToSeconds() {
                TimeSpan returned = value.Seconds();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerSecond), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMinute - 1), spec.Maximum);
            }
        }

        public class Minutes: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToMinutes() {
                TimeSpan returned = value.Minutes();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMinute), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerHour - 1), spec.Maximum);
            }
        }

        public class Hours: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToHours() {
                TimeSpan returned = value.Hours();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerHour), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay - 1), spec.Maximum);
            }
        }

        public class Days: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToDays() {
                TimeSpan returned = value.Days();

                Assert.Equal(newValue, returned);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay), spec.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay * 7 - 1), spec.Maximum);
            }
        }
    }
}
