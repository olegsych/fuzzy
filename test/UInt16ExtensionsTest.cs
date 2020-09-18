using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class UInt16ExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<ushort> value;
        readonly ushort minimum = (ushort)(ushort.MinValue + random.Next() % byte.MaxValue);
        readonly ushort maximum = (ushort)(ushort.MaxValue - random.Next() % byte.MaxValue);

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<ushort> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public UInt16ExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<ushort>>(fuzzy, ushort.MinValue, ushort.MaxValue);

        public class Between: UInt16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<ushort> returned = value.Between(minimum, maximum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Maximum: UInt16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Maximum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                FuzzyRange<ushort> returned = value.Maximum(maximum);
                Assert.Same(value, returned);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Minimum: UInt16ExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Minimum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                FuzzyRange<ushort> returned = value.Minimum(minimum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
            }
        }
    }
}
