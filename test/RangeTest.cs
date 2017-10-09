using System;
using Xunit;

namespace Fuzzy
{
    public class RangeTest
    {
        static readonly Random random = new Random();

        public class Between : RangeTest
        {
            readonly int min = random.Next() % 1000;
            readonly int max ;

            public Between() => max = min + random.Next() % 10;

            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues()
            {
                var sut = TestRange.Between(min, max);
                Assert.Equal(min, sut.Minimum);
                Assert.Equal(max, sut.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMaxIsLessThanMin()
            {
                var e = Assert.Throws<ArgumentException>(() => TestRange.Between(min, min - 1));
                Assert.Contains(min.ToString(), e.Message);
                Assert.Contains((min - 1).ToString(), e.Message);
            }
        }

        public class Max : RangeTest
        {
            readonly int max = random.Next();

            [Fact]
            public void ReturnsRangeInitializedWithGivenMaximumValue()
            {
                var sut = TestRange.Max(max);
                Assert.Equal(max, sut.Maximum);
            }

            [Fact]
            public void ReturnsRangeWithMinimumValueLessThanGivenMaximum()
            {
                var sut = TestRange.Max(2);
                Assert.True(sut.Minimum < sut.Maximum);
            }
        }

        public class Min : RangeTest
        {
            readonly int min = random.Next();

            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumValue()
            {
                var sut = TestRange.Min(min);
                Assert.Equal(min, sut.Minimum);
            }

            [Fact]
            public void ReturnsRangeWithMaximumGreaterThanGivenMinimum()
            {
                var sut = TestRange.Min(14);
                Assert.True(sut.Minimum < sut.Maximum);
            }
        }

        sealed class TestRange : Range<TestRange> { }
    }
}
