using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class SByteExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<sbyte> value;
        readonly sbyte minimum = (sbyte)(sbyte.MinValue + random.Next() % 64);
        readonly sbyte maximum = (sbyte)(sbyte.MaxValue - random.Next() % 64);

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<sbyte> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public SByteExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<sbyte>>(fuzzy, sbyte.MinValue, sbyte.MaxValue);

        public class Between: SByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<sbyte> returned = value.Between(minimum, maximum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Maximum: SByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Maximum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                FuzzyRange<sbyte> returned = value.Maximum(maximum);
                Assert.Same(value, returned);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Minimum: SByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Minimum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                FuzzyRange<sbyte> returned = value.Minimum(minimum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
            }
        }
    }
}
