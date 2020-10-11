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
        readonly int minimum = random.Next() % 1000;
        readonly int maximum;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public SizeTest() => maximum = minimum + random.Next() % 10;

        public class Between: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues() {
                var sut = TestSize.Between(minimum, maximum);

                FuzzyRange<int> actual = sut.New(fuzzy);
                Assert.Equal(minimum, actual.Minimum);
                Assert.Equal(maximum, actual.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMaxIsLessThanMin() {
                var thrown = Assert.Throws<ArgumentException>(() => TestSize.Between(minimum, minimum - 1));
                Method method = typeof(TestSize).Method(nameof(TestSize.Between));
                Assert.Equal(method.Parameter<int>("max").Name, thrown.ParamName);
                Assert.Contains(minimum.ToString(), thrown.Message);
                Assert.Contains((minimum - 1).ToString(), thrown.Message);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMinIsLessThan0() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Between(-1, maximum));
        }

        public class Max: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMaximumValue() {
                var sut = TestSize.Max(maximum);

                FuzzyRange<int> actual = sut.New(fuzzy);
                Assert.Equal(maximum, actual.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0() {
                var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Max(-1));
                Method method = typeof(TestSize).Method(nameof(TestSize.Max));
                Assert.Equal(method.Parameter<int>().Name, thrown.ParamName);
            }
        }

        public class Min: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumValueAndNoMaximum() {
                var sut = TestSize.Min(minimum);

                FuzzyRange<int> actual = sut.New(fuzzy);
                Assert.Equal(minimum, actual.Minimum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0() {
                var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Min(-1));
                Method method = typeof(TestSize).Method(nameof(TestSize.Min));
                Assert.Equal(method.Parameter<int>().Name, thrown.ParamName);
            }
        }

        public class New: SizeTest
        {
            Size<TestSize> sut;

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                sut = new TestSize();

                var thrown = Assert.Throws<ArgumentNullException>(() => sut.New(null));

                Assert.Equal(sut.Method(nameof(sut.New)).Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithGivenMinimumAndMaximum() {
                sut = TestSize.Between(minimum, maximum);

                FuzzyRange<int> actual = sut.New(fuzzy);

                Assert.Equal(minimum, actual.Minimum);
                Assert.Equal(maximum, actual.Maximum);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithDefaultMinimumAndMaximum() {
                sut = new TestSize();

                FuzzyRange<int> actual = sut.New(fuzzy);

                Assert.Equal(8, actual.Minimum);
                Assert.Equal(13, actual.Maximum);
            }

            [Theory]
            [InlineData(7, 2)]
            [InlineData(1, 1)]
            [InlineData(0, 0)]
            public void ReturnsFuzzyInt32WhenMaximumIsLessThanDefaultMinimum(int maximum, int expectedMinimum) {
                sut = TestSize.Max(maximum);

                FuzzyRange<int> actual = sut.New(fuzzy);

                Assert.Equal(expectedMinimum, actual.Minimum);
                Assert.Equal(maximum, actual.Maximum);
            }

            [Theory]
            [InlineData(13, 18)]
            [InlineData(14, 19)]
            public void ReturnsFuzzyInt32WhenMinimumIsMoreThanDefaultMaximum(int minimum, int expectedMaximum) {
                sut = TestSize.Min(minimum);

                FuzzyRange<int> actual = sut.New(fuzzy);

                Assert.Equal(expectedMaximum, actual.Maximum);
                Assert.Equal(minimum, actual.Minimum);
            }
        }

        sealed class TestSize: Size<TestSize> { }
    }
}
