using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class RangeTest
    {
        static readonly Random random = new Random();

        // Common method parameters
        readonly int min = random.Next() % 1000;
        readonly int max;

        public RangeTest() => max = min + random.Next() % 10;

        public class Between: RangeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues() {
                var sut = TestRange.Between(min, max);
                Assert.Equal(min, sut.Minimum);
                Assert.Equal(max, sut.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMaxIsLessThanMin() {
                var e = Assert.Throws<ArgumentException>(() => TestRange.Between(min, min - 1));
                Assert.Contains(min.ToString(), e.Message);
                Assert.Contains((min - 1).ToString(), e.Message);
            }
        }

        public class Max: RangeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMaximumValue() {
                var sut = TestRange.Max(max);
                Assert.Equal(max, sut.Maximum);
            }

            [Fact]
            public void ReturnsRangeWithMinimumValueLessThanGivenMaximum() {
                var sut = TestRange.Max(2);
                Assert.True(sut.Minimum < sut.Maximum);
            }
        }

        public class Min: RangeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumValue() {
                var sut = TestRange.Min(min);
                Assert.Equal(min, sut.Minimum);
            }

            [Fact]
            public void ReturnsRangeWithMaximumGreaterThanGivenMinimum() {
                var sut = TestRange.Min(14);
                Assert.True(sut.Minimum < sut.Maximum);
            }
        }

        public class New: RangeTest
        {
            readonly Range<TestRange> sut;

            // Method parameters
            readonly IFuzz fuzzy = Substitute.For<IFuzz>();

            public New() => sut = TestRange.Between(min, max);

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => sut.New(null));
                Assert.Equal(sut.Method<Func<IFuzz, int>>().Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithGivenMinimumAndMaximum() {
                int expected = random.Next();
                Expression<Predicate<FuzzyRange<int>>> fuzzyUInt32 = v => v.Minimum == sut.Minimum && v.Maximum == sut.Maximum;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyUInt32)).Returns(expected);

                int actual = sut.New(fuzzy);

                Assert.Equal(expected, actual);
            }
        }

        sealed class TestRange: Range<TestRange> { }
    }
}
