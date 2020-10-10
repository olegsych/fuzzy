using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class SizeTest
    {
        static readonly Random random = new Random();

        // Common method parameters
        readonly int min = random.Next() % 1000;
        readonly int max;

        public SizeTest() => max = min + random.Next() % 10;

        public class Between: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues() {
                var sut = TestSize.Between(min, max);
                Assert.Equal(min, sut.Minimum);
                Assert.Equal(max, sut.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMaxIsLessThanMin() {
                var e = Assert.Throws<ArgumentException>(() => TestSize.Between(min, min - 1));
                Assert.Contains(min.ToString(), e.Message);
                Assert.Contains((min - 1).ToString(), e.Message);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMinIsLessThan0() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Between(-1, max));
        }

        public class Max: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMaximumValueAndNoMinimum() {
                var sut = TestSize.Max(max);
                Assert.Equal(max, sut.Maximum);
                Assert.Null(sut.Minimum);
            }
        }

        public class Min: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumValueAndNoMaximum() {
                var sut = TestSize.Min(min);
                Assert.Equal(min, sut.Minimum);
                Assert.Null(sut.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Min(-1));
        }

        public class New: SizeTest
        {
            readonly Size<TestSize> sut;

            // Method parameters
            readonly IFuzz fuzzy = Substitute.For<IFuzz>();

            public New() => sut = TestSize.Between(min, max);

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

        sealed class TestSize: Size<TestSize> { }
    }
}
