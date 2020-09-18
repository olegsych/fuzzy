using System;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class ByteExtensionsTest
    {
        // Method parameters
        readonly FuzzyRange<byte> value;
        readonly byte minimum = (byte)(byte.MinValue + random.Next() % sbyte.MaxValue);
        readonly byte maximum = (byte)(byte.MaxValue - random.Next() % sbyte.MaxValue);

        // Shared test fixture
        static readonly Random random = new Random();
        readonly FuzzyRange<byte> @null = null;
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public ByteExtensionsTest() =>
            value = Substitute.ForPartsOf<FuzzyRange<byte>>(fuzzy, byte.MinValue, byte.MaxValue);

        public class Between: ByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Between(minimum, maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                FuzzyRange<byte> returned = value.Between(minimum, maximum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Maximum: ByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Maximum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                FuzzyRange<byte> returned = value.Maximum(maximum);
                Assert.Same(value, returned);
                Assert.Equal(maximum, returned.Maximum);
            }
        }

        public class Minimum: ByteExtensionsTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => @null.Minimum(maximum));
                Assert.Equal("value", thrown.ParamName);
            }

            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                FuzzyRange<byte> returned = value.Minimum(minimum);
                Assert.Same(value, returned);
                Assert.Equal(minimum, returned.Minimum);
            }
        }
    }
}
