using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class Int16ExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<short> value;
        readonly short minimum = (short)(short.MinValue + random.Next() % byte.MaxValue);
        readonly short maximum = (short)(short.MaxValue - random.Next() % byte.MaxValue);

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<short> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public Int16ExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<short>>(fuzzy, short.MinValue, short.MaxValue);

        public class Between: Int16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<short> returned = value.Between(minimum, maximum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Maximum: Int16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Maximum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                FuzzyRange<short> returned = value.Maximum(maximum);
                Assert.Same(value, returned);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Minimum: Int16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Minimum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                FuzzyRange<short> returned = value.Minimum(minimum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
            }
        }
    }
}
