using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class UInt16ExtensionsTest: TestFixture
    {
        // Method parameters
        readonly ushort value = (ushort)(random.Next() % ushort.MaxValue);
        readonly ushort minimum = (ushort)(ushort.MinValue + random.Next() % short.MaxValue);
        readonly ushort maximum = (ushort)(ushort.MaxValue - random.Next() % short.MaxValue);

        // Test fixture
        readonly FuzzyRange<ushort> spec;
        readonly ushort newValue = (ushort)(random.Next() % ushort.MaxValue);

        public UInt16ExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<ushort>>(fuzzy, ushort.MinValue, ushort.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: UInt16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                ushort returned = value.Between(minimum, maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Maximum: UInt16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                ushort returned = value.Maximum(maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Minimum: UInt16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                ushort returned = value.Minimum(minimum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
            }
        }
    }
}
