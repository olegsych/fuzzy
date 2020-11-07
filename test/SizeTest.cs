using System;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class SizeTest: TestFixture
    {
        // Common method parameters
        readonly int minimum = 2 + random.Next() % 1000;
        readonly int maximum;

        // Shared test fixture
        readonly int builtValue = random.Next();

        public SizeTest() {
            maximum = minimum + random.Next() % 10;
            ArrangeBuildOfFuzzyInt32();
        }

        public class Between: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues() {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == minimum && s.Maximum == maximum)).Returns(builtValue);

                var sut = TestSize.Between(minimum, maximum);

                Assert.Equal(builtValue, sut.Build(fuzzy));
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

        public new class Equals: SizeTest
        {
            [Theory]
            [InlineData(null, null, true)]
            [InlineData(42, 42, true)]
            [InlineData(null, 42, false)]
            [InlineData(42, null, false)]
            public void ReturnsValueBasedOnMinimum(int? firstMinimum, int? secondMinimum, bool expected) {
                var firstSize = new TestSize(firstMinimum, null);
                var secondSize = new TestSize(secondMinimum, null);
                Assert.Equal(expected, firstSize.Equals(secondSize));
            }

            [Theory]
            [InlineData(null, null, true)]
            [InlineData(42, 42, true)]
            [InlineData(null, 42, false)]
            [InlineData(42, null, false)]
            public void ReturnsValueBasedOnMaximum(int? firstMaximum, int? secondMaximum, bool expected) {
                var firstSize = new TestSize(null, firstMaximum);
                var secondSize = new TestSize(null, secondMaximum);
                Assert.Equal(expected, firstSize.Equals(secondSize));
            }

            [Fact]
            public void ReturnsFalseWhenOtherIsNotSize() =>
                Assert.NotEqual(new TestSize(), new object());
        }

        public class Exactly: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenValueValue() {
                int expected = random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == expected && s.Maximum == expected)).Returns(builtValue);

                var sut = TestSize.Exactly(expected);

                Assert.Equal(builtValue, sut.Build(fuzzy));
            }
        }

        public new class GetHashCode: SizeTest
        {
            [Theory]
            [InlineData(null, null)]
            [InlineData(null, 42)]
            [InlineData(42, null)]
            [InlineData(42, 42)]
            public void ReturnsValueBasedOnMinimumAndMaximum(int? minimum, int? maximum) {
                var actual = new TestSize(minimum, maximum);
                (int? minimum, int? maximum) expected = (minimum, maximum);
                Assert.Equal(expected.GetHashCode(), actual.GetHashCode());
            }
        }

        public class Max: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMaximumValue() {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Maximum == maximum)).Returns(builtValue);

                var sut = TestSize.Max(maximum);

                Assert.Equal(builtValue, sut.Build(fuzzy));
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
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == minimum)).Returns(builtValue);

                var sut = TestSize.Min(minimum);

                Assert.Equal(builtValue, sut.Build(fuzzy));
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0() {
                var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => TestSize.Min(-1));
                Method method = typeof(TestSize).Method(nameof(TestSize.Min));
                Assert.Equal(method.Parameter<int>().Name, thrown.ParamName);
            }
        }

        public class Build: SizeTest
        {
            Size<TestSize> sut;

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                sut = new TestSize();

                var thrown = Assert.Throws<ArgumentNullException>(() => sut.Build(null));

                Assert.Equal(sut.Method(nameof(sut.Build)).Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithGivenMinimumAndMaximum() {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == minimum && s.Maximum == maximum)).Returns(builtValue);
                sut = TestSize.Between(minimum, maximum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithDefaultMinimumAndMaximum() {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == 8 && s.Maximum == 13)).Returns(builtValue);
                sut = new TestSize();

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
            }

            [Theory]
            [InlineData(7, 2)]
            [InlineData(1, 1)]
            [InlineData(0, 0)]
            public void ReturnsFuzzyInt32WhenMaximumIsLessThanDefaultMinimum(int maximum, int expectedMinimum) {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == expectedMinimum && s.Maximum == maximum)).Returns(builtValue);
                sut = TestSize.Max(maximum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
            }

            [Theory]
            [InlineData(13, 18)]
            [InlineData(14, 19)]
            public void ReturnsFuzzyInt32WhenMinimumIsMoreThanDefaultMaximum(int minimum, int expectedMaximum) {
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<int>>(s => s.Minimum == minimum && s.Maximum == expectedMaximum)).Returns(builtValue);
                sut = TestSize.Min(minimum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
            }
        }

        sealed class TestSize: Size<TestSize>
        {
            public TestSize() { }
            public TestSize(int? minimum, int? maximum) => base.Initialize(minimum, maximum);
        }
    }
}
