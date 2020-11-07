using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class Int16ExtensionsTest: TestFixture
    {
        // Method parameters
        readonly short value = (short)(random.Next() % 64);
        readonly short minimum = (short)(short.MinValue + random.Next() % byte.MaxValue);
        readonly short maximum = (short)(short.MaxValue - random.Next() % byte.MaxValue);

        // Test fixture
        readonly FuzzyRange<short> spec;
        readonly short newValue = (short)(random.Next() % short.MaxValue);

        public Int16ExtensionsTest() {
            spec = Substitute.ForPartsOf<FuzzyRange<short>>(fuzzy, short.MinValue, short.MaxValue);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: Int16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                short returned = value.Between(minimum, maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Maximum: Int16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                short returned = value.Maximum(maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Minimum: Int16ExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                short returned = value.Minimum(minimum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
            }
        }
    }
}
