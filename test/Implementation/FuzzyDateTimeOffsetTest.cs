using System;
using System.Collections.Generic;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyDateTimeOffsetTest: TestFixture
    {
        readonly FuzzyRange<DateTimeOffset> sut;

        public FuzzyDateTimeOffsetTest() =>
            sut = new FuzzyDateTimeOffset(fuzzy);

        public class Constructor: FuzzyDateTimeOffsetTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(DateTimeOffset.MinValue, sut.Minimum);
                Assert.Equal(DateTimeOffset.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyDateTimeOffsetTest
        {
            public Build() => ArrangeBuildOfFuzzyInt64();

            [Theory, MemberData(nameof(GetData))]
            public void ReturnsDateTimeOffsetCreatedFromFuzzyTicksAndOffsetValues(DateTimeOffset minimum, DateTimeOffset maximum, DateTime fuzzyDate, TimeSpan fuzzyOffset, DateTimeOffset expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<long>>(v => v.Minimum == sut.Minimum.Ticks && v.Maximum == sut.Maximum.Ticks)).Returns(fuzzyDate.Ticks);
                var maxOffset = TimeSpan.FromMinutes(14 * 60);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(v => v.Minimum == -maxOffset.TotalMinutes && v.Maximum == maxOffset.TotalMinutes)).Returns((int)fuzzyOffset.TotalMinutes);

                DateTimeOffset actual = sut.Build();

                Assert.True(minimum <= actual && actual <= maximum, $"Value {actual.UtcDateTime:o} is out of the expected range [{minimum.UtcDateTime:o}..{maximum.UtcDateTime:o}]");
                Assert.Equal(expected, actual);
                Assert.Equal(expected.UtcDateTime, actual.UtcDateTime);
                Assert.Equal(expected.Offset, actual.Offset);
            }

            public static IEnumerable<object[]> GetData() {
                var now = DateTimeOffset.Now;
                DateTime utc = now.UtcDateTime;
                var minute = TimeSpan.FromMinutes(1);

                // Theory parameters:       minimum,                 maximum,                 fuzzyDate,         fuzzyOffset,   expectedResult

                // No min/max, without offset
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, utc,               TimeSpan.Zero, new DateTimeOffset(utc, TimeSpan.Zero) };
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTime.MinValue, TimeSpan.Zero, DateTimeOffset.MinValue };
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTime.MaxValue, TimeSpan.Zero, DateTimeOffset.MaxValue };

                // No min/max, With offset
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, utc,               minute,        new DateTimeOffset(utc.Ticks, minute) };
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTime.MinValue, minute,        new DateTimeOffset((DateTime.MinValue + minute).Ticks, minute) };
                yield return new object[] { DateTimeOffset.MinValue, DateTimeOffset.MaxValue, DateTime.MaxValue, -minute,       new DateTimeOffset((DateTime.MaxValue - minute).Ticks, -minute) };

                // Min/max in UTC
                yield return new object[] { utc - minute,            utc + minute,            utc,               TimeSpan.Zero, new DateTimeOffset(utc, TimeSpan.Zero) }; // Middle, no offset
                yield return new object[] { utc - minute,            utc + minute,            utc,               minute,        new DateTimeOffset(utc.Ticks, minute) };  // Middle, with offset
                yield return new object[] { utc - minute,            utc + minute,            utc - minute,      minute,        new DateTimeOffset(utc.Ticks, minute) };  // Min, with offset
                yield return new object[] { utc - minute,            utc + minute,            utc + minute,      -minute,       new DateTimeOffset(utc.Ticks, -minute) }; // Max, with offset

                // Min/max with offset
                yield return new object[] { now - minute,            now + minute,            utc,               TimeSpan.Zero, new DateTimeOffset(utc, TimeSpan.Zero) }; // Middle, no offset
                yield return new object[] { now - minute,            now + minute,            utc,               minute,        new DateTimeOffset(utc.Ticks, minute) };  // Middle, with offset
                yield return new object[] { now - minute,            now + minute,            utc - minute,      minute,        new DateTimeOffset(utc.Ticks, minute) };  // Min, with offset
                yield return new object[] { now - minute,            now + minute,            utc + minute,      -minute,       new DateTimeOffset(utc.Ticks, -minute) }; // Max, with offset
            }
        }
    }
}
