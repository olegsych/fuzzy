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
        FuzzyRange<int> buildSpec;
        readonly int builtValue = random.Next();

        public SizeTest() {
            maximum = minimum + random.Next() % 10;
            ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyRange<int>>(spec => buildSpec = spec)).Returns(builtValue);
        }

        public class Between: SizeTest
        {
            [Fact]
            public void ReturnsRangeInitializedWithGivenMinimumAndMaximumValues() {
                var sut = TestSize.Between(minimum, maximum);

                Assert.Equal(builtValue, sut.Build(fuzzy));
                Assert.Equal(minimum, buildSpec.Minimum);
                Assert.Equal(maximum, buildSpec.Maximum);
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

                var sut = TestSize.Exactly(expected);

                Assert.Equal(builtValue, sut.Build(fuzzy));
                Assert.Equal(expected, buildSpec.Maximum);
                Assert.Equal(expected, buildSpec.Minimum);
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
                var sut = TestSize.Max(maximum);

                Assert.Equal(builtValue, sut.Build(fuzzy));
                Assert.Equal(maximum, buildSpec.Maximum);
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

                Assert.Equal(builtValue, sut.Build(fuzzy));
                Assert.Equal(minimum, buildSpec.Minimum);
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
                sut = TestSize.Between(minimum, maximum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
                Assert.Equal(minimum, buildSpec.Minimum);
                Assert.Equal(maximum, buildSpec.Maximum);
            }

            [Fact]
            public void ReturnsFuzzyInt32WithDefaultMinimumAndMaximum() {
                sut = new TestSize();

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
                Assert.Equal(8, buildSpec.Minimum);
                Assert.Equal(13, buildSpec.Maximum);
            }

            [Theory]
            [InlineData(7, 2)]
            [InlineData(1, 1)]
            [InlineData(0, 0)]
            public void ReturnsFuzzyInt32WhenMaximumIsLessThanDefaultMinimum(int maximum, int expectedMinimum) {
                sut = TestSize.Max(maximum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
                Assert.Equal(expectedMinimum, buildSpec.Minimum);
                Assert.Equal(maximum, buildSpec.Maximum);
            }

            [Theory]
            [InlineData(13, 18)]
            [InlineData(14, 19)]
            public void ReturnsFuzzyInt32WhenMinimumIsMoreThanDefaultMaximum(int minimum, int expectedMaximum) {
                sut = TestSize.Min(minimum);

                int actual = sut.Build(fuzzy);

                Assert.Equal(builtValue, actual);
                Assert.Equal(expectedMaximum, buildSpec.Maximum);
                Assert.Equal(minimum, buildSpec.Minimum);
            }
        }

        sealed class TestSize: Size<TestSize>
        {
            public TestSize() { }
            public TestSize(int? minimum, int? maximum) => base.Initialize(minimum, maximum);
        }
    }
}
