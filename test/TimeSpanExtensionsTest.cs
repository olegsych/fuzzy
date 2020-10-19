using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class TimeSpanExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<TimeSpan> value;

        // Shared test fixture
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public TimeSpanExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<TimeSpan>>(fuzzy, TimeSpan.MinValue, TimeSpan.MaxValue);

        public class Ticks: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToTicks() {
                FuzzyRange<TimeSpan> actual = value.Ticks();
                Assert.Equal(new TimeSpan(1), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMillisecond - 1), actual.Maximum);
            }
        }

        public class Milliseconds: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToMilliseconds() {
                FuzzyRange<TimeSpan> actual = value.Milliseconds();
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMillisecond), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerSecond - 1), actual.Maximum);
            }
        }

        public class Seconds: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToSeconds() {
                FuzzyRange<TimeSpan> actual = value.Seconds();
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerSecond), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMinute - 1), actual.Maximum);
            }
        }

        public class Minutes: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToMinutes() {
                FuzzyRange<TimeSpan> actual = value.Minutes();
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerMinute), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerHour - 1), actual.Maximum);
            }
        }

        public class Hours: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToHours() {
                FuzzyRange<TimeSpan> actual = value.Hours();
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerHour), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay - 1), actual.Maximum);
            }
        }

        public class Days: TimeSpanExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpanConstrainedToDays() {
                FuzzyRange<TimeSpan> actual = value.Days();
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay), actual.Minimum);
                Assert.Equal(new TimeSpan(TimeSpan.TicksPerDay * 7 - 1), actual.Maximum);
            }
        }
    }
}
