using System;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class IComparableExtensionsTest: FuzzyTestFixture
    {
        // Method parameters
        readonly TestStruct value;
        readonly FuzzyRange<TestStruct> spec;
        readonly TestStruct minimum;
        readonly TestStruct maximum;

        // Test fixture
        readonly TestStruct newValue;

        public IComparableExtensionsTest() {
            value = new TestStruct(random.Next());
            spec = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, new TestStruct(int.MinValue), new TestStruct(int.MaxValue));
            minimum = new TestStruct(int.MinValue + random.Next() % short.MaxValue);
            maximum = new TestStruct(int.MaxValue - random.Next() % short.MaxValue);
            newValue = new TestStruct(random.Next());

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class Between: IComparableExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumAndMaximumPropertiesSet() {
                TestStruct returned = value.Between(minimum, maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Maximum: IComparableExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMaximumPropertySet() {
                TestStruct returned = value.Maximum(maximum);

                Assert.Equal(newValue, returned);
                Assert.Equal(maximum, spec.Maximum);
            }
        }

        public class Minimum: IComparableExtensionsTest
        {
            [Fact]
            public void ReturnsValueWithMinimumPropertySet() {
                TestStruct returned = spec.Minimum(minimum);

                Assert.Equal(newValue, returned);
                Assert.Equal(minimum, spec.Minimum);
            }
        }
    }
}
