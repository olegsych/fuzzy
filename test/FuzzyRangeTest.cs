using System;
using System.Reflection;
using Inspector;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class FuzzyRangeTest
    {
        readonly FuzzyRange<TestStruct> sut;

        // Constructor parameters
        readonly IFuzz fuzz = Substitute.For<IFuzz>();
        readonly TestStruct minimum;
        readonly TestStruct maximum;

        public FuzzyRangeTest() {
            int minimumValue = random.Next();
            minimum = new TestStruct(minimumValue);
            maximum = new TestStruct(minimumValue + 1);
            sut = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzz, minimum, maximum);
        }

        public class Constructor: FuzzyRangeTest
        {
            [Fact]
            public void CallsBaseConstructor() =>
                Assert.Same(fuzz, sut.DeclaredBy<Fuzzy<TestStruct>>().Field<IFuzz>().Value);

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMaximumIsLessThanMinimum() {
                var invalid = new TestStruct(minimum.Value - 1);

                var wrapped = Assert.Throws<TargetInvocationException>(() => Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzz, minimum, invalid));

                var thrown = Assert.IsType<ArgumentOutOfRangeException>(wrapped.InnerException);
                Assert.Equal("maximum", thrown.ParamName);
                Assert.Contains("minimum", thrown.Message);
                Assert.Contains(invalid.ToString(), thrown.Message);
                Assert.Contains(minimum.ToString(), thrown.Message);
            }
        }

        public class Maximum: FuzzyRangeTest
        {
            [Fact]
            public void IsInitializedByConstructor() =>
                Assert.Equal(maximum, sut.Maximum);

            [Fact]
            public void CanBeSet() {
                var expected = new TestStruct(minimum.Value + 1);
                sut.Maximum = expected;
                Assert.Equal(expected, sut.Maximum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenNewValueIsLessThanMinimum() {
                int value = minimum.Value - 1;

                var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Maximum = new TestStruct(value));

                Assert.Equal("value", thrown.ParamName);
                Assert.Contains(nameof(sut.Minimum), thrown.Message);
                Assert.Contains(value.ToString(), thrown.Message);
                Assert.Contains(minimum.ToString(), thrown.Message);
            }
        }

        public class Minimum: FuzzyRangeTest
        {
            [Fact]
            public void IsInitializedByConstructor() =>
                Assert.Equal(minimum, sut.Minimum);

            [Fact]
            public void CanBeSet() {
                var expected = new TestStruct(maximum.Value - 1);
                sut.Minimum = expected;
                Assert.Equal(expected, sut.Minimum);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenNewValueIsGreaterThanMaximum() {
                int value = maximum.Value + 1;

                var thrown = Assert.Throws<ArgumentOutOfRangeException>(() => sut.Minimum = new TestStruct(value));

                Assert.Equal("value", thrown.ParamName);
                Assert.Contains(nameof(sut.Maximum), thrown.Message);
                Assert.Contains(value.ToString(), thrown.Message);
                Assert.Contains(maximum.ToString(), thrown.Message);
            }
        }

        public struct TestStruct: IComparable<TestStruct>
        {
            public readonly int Value;
            public TestStruct(int value) => Value = value;
            public int CompareTo(TestStruct other) => Value.CompareTo(other.Value);
            public bool Equals(TestStruct other) => Value.Equals(other.Value);
            public override string ToString() => Value.ToString();
        }

        static readonly Random random = new Random();
    }
}
