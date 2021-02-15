using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyContextTest: TestFixture
    {
        // Method parameters
        readonly TestStruct value;
        readonly FuzzyRange<TestStruct> spec;

        public FuzzyContextTest() {
            value = new TestStruct(random.Next());
            spec = CreateSpec();
        }

        FuzzyRange<TestStruct> CreateSpec() =>
            Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, new TestStruct(int.MinValue), new TestStruct(int.MaxValue));

        [Fact]
        public void SetThrowsDescriptiveExceptionWhenSpecIsNull() {
            var thrown = Assert.Throws<ArgumentNullException>(() => FuzzyContext.Set(value, null!));
            Assert.Equal("spec", thrown.ParamName);
        }

        [Fact]
        public void SetStoresValueForGet() {
            FuzzyContext.Set(value, spec);
            Assert.Same(spec, FuzzyContext.Get<TestStruct, FuzzyRange<TestStruct>>(value));
        }

        [Fact]
        public void GetThrowsDescriptiveExceptionWhenValueDoesNotMatchPreviouslyStored() {
            FuzzyContext.Set(value, spec);

            var unexpected = new TestStruct(random.Next());
            var thrown = Assert.Throws<ArgumentException>(() => FuzzyContext.Get<TestStruct, FuzzyRange<TestStruct>>(unexpected));

            Assert.Equal("value", thrown.ParamName);
            Assert.StartsWith($"{unexpected} is not a fuzzy value", thrown.Message);
        }

        [Fact]
        public void SetStoresValuesSeparatelyForEachThread() {
            // Arrange
            TestStruct[] values = Enumerable.Range(0, 16).Select(i => new TestStruct(random.Next())).ToArray();
            FuzzyRange<TestStruct>[] specs = values.Select(v => CreateSpec()).ToArray();
            ParallelLoopResult unused = Parallel.For(0, values.Length, i => {
                TestStruct value = values[i];
                FuzzyRange<TestStruct> expected = specs[i];

                // Act
                FuzzyContext.Set(value, expected);
                Thread.Sleep(1);
                FuzzyRange<TestStruct> actual = FuzzyContext.Get<TestStruct, FuzzyRange<TestStruct>>(value);

                // Assert
                Assert.Same(expected, actual);
            });
        }
    }
}
