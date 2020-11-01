using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class SByteExtensionsTest: TestFixture
    {
        // Method parameters
        readonly sbyte value = (sbyte)(random.Next() % 64);
        readonly sbyte minimum = (sbyte)(sbyte.MinValue + random.Next() % 64);
        readonly sbyte maximum = (sbyte)(sbyte.MaxValue - random.Next() % 64);

        // Test fixture
        readonly FuzzyRange<sbyte> spec;
        readonly sbyte newValue = (sbyte)(random.Next() % sbyte.MaxValue);

        public SByteExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<sbyte>>(fuzzy, sbyte.MinValue, sbyte.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: SByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                sbyte returned = value.Between(minimum, maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Maximum: SByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                sbyte returned = value.Maximum(maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Minimum: SByteExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                sbyte returned = value.Minimum(minimum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
            }
        }
    }
}
