using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyDictionaryTest: TestFixture
    {
        readonly Fuzzy<Dictionary<TestKey, TestValue>> sut;

        // Constructor parameters
        readonly Func<TestKey> keyFactory = Substitute.For<Func<TestKey>>();
        readonly Func<TestKey, TestValue> valueFactory = Substitute.For<Func<TestKey, TestValue>>();
        readonly Count count;

        // Test fixture
        readonly int minCount;
        readonly int maxCount;

        FuzzyDictionaryTest() {
            minCount = 1 + random.Next() % 10;
            maxCount = minCount + 1 + random.Next() % 10;
            count = Count.Between(minCount, maxCount);
            sut = new FuzzyDictionary<TestKey, TestValue>(fuzzy, keyFactory, valueFactory, count);
        }

        public class Constructor: FuzzyDictionaryTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyDictionary<TestKey, TestValue>(null!, keyFactory, valueFactory, count));
                Assert.Equal(sut.Constructor().Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenKeyFactoryIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyDictionary<TestKey, TestValue>(fuzzy, null!, valueFactory, count));
                Assert.Equal(sut.Constructor().Parameter<Func<TestKey>>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueFactoryIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyDictionary<TestKey, TestValue>(fuzzy, keyFactory, null!, count));
                Assert.Equal(sut.Constructor().Parameter<Func<TestKey, TestValue>>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenCountIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyDictionary<TestKey, TestValue>(fuzzy, keyFactory, valueFactory, null!));
                Assert.Equal(sut.Constructor().Parameter<Count>().Name, thrown.ParamName);
            }
        }

        public class Build: FuzzyDictionaryTest
        {
            public Build() => ArrangeBuildOfFuzzyInt32();

            [Fact]
            public void ReturnsDictionaryWithGivenCountAndItemsCreatedByFactories() {
                int expectedCount = 2 + random.Next() % 10;
                Expression<Predicate<FuzzyRange<int>>> fuzzyCount = f => f.Minimum == minCount && f.Maximum == maxCount;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyCount)).Returns(expectedCount);
                TestKey[] keys = Enumerable.Range(0, expectedCount).Select(i => new TestKey()).ToArray();
                Dictionary<TestKey, TestValue> values = keys.ToDictionary(key => key, key => new TestValue());
                arrange = keyFactory.Invoke().Returns(keys.First(), keys.Skip(1).ToArray());
                arrange = valueFactory.Invoke(Arg.Any<TestKey>()).Returns(args => values[(TestKey)args[0]]);

                Dictionary<TestKey, TestValue> result = sut.Build();

                Assert.Equal(values, result);
            }
        }

        public class TestKey { }
        public class TestValue { }
    }
}
