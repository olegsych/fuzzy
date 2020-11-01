using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class ByteExtensionsTest: TestFixture
    {
        // Method parameters
        readonly byte value = (byte)(random.Next() % byte.MaxValue);
        readonly byte minimum = (byte)(byte.MinValue + random.Next() % sbyte.MaxValue);
        readonly byte maximum = (byte)(byte.MaxValue - random.Next() % sbyte.MaxValue);

        // Test fixture
        readonly FuzzyRange<byte> spec;
        readonly byte newValue = (byte)(random.Next() % byte.MaxValue);

        public ByteExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<byte>>(fuzzy, byte.MinValue, byte.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: ByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                byte returned = value.Between(minimum, maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Maximum: ByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                byte returned = value.Maximum(maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Minimum: ByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                byte returned = value.Minimum(minimum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
            }
        }
    }
}
