using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class FuzzyRangeExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<TestStruct> value;
        readonly TestStruct minimum = new TestStruct(int.MinValue + random.Next() % short.MaxValue);
        readonly TestStruct maximum = new TestStruct(int.MaxValue - random.Next() % short.MaxValue);

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<TestStruct> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public FuzzyRangeExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, new TestStruct(int.MinValue), new TestStruct(int.MaxValue));

        public class Between: FuzzyRangeExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<TestStruct> returned = value.Between(minimum, maximum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Maximum: FuzzyRangeExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Maximum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                FuzzyRange<TestStruct> returned = value.Maximum(maximum);
                Assert.Same(value, returned);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Minimum: FuzzyRangeExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Minimum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                FuzzyRange<TestStruct> returned = value.Minimum(minimum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
            }
        }
    }
}
