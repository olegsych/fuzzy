using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fuzzy.Implementation;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public abstract class IFuzzDictionaryExtensionsTest: TestFixture
    {
        // Test fixture
        readonly Dictionary<TestKey, TestValue> expected = new Dictionary<TestKey, TestValue>();
        FuzzyDictionary<TestKey, TestValue> spec;
        ConfiguredCall arrange;

        public IFuzzDictionaryExtensionsTest() {
            ConfiguredCall unused = fuzzy.Build(Arg.Do<FuzzyDictionary<TestKey, TestValue>>(s => spec = s)).Returns(expected);
        }

        public class DictionaryFuncOfTValue: IFuzzDictionaryExtensionsTest
        {
            // Method parameters
            readonly Func<TestKey> createKey = Substitute.For<Func<TestKey>>();
            readonly Func<TestValue> createValue = Substitute.For<Func<TestValue>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyDictionaryWithGivenFuzzFactoryAndCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(createKey, createValue, count);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Same(count, spec.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyDictionaryWithDefaultCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(createKey, createValue);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Equal(new Count(), spec.Field<Count>().Value);
            }

            protected override void AssertExpectedKeyFactory() =>
                Assert.Same(createKey, spec.Field<Func<TestKey>>().Value);

            protected override void AssertExpectedValueFactory() {
                var expectedValue = new TestValue();
                arrange = createValue.Invoke().Returns(expectedValue);

                TestValue actualValue = spec.Field<Func<TestKey, TestValue>>().Value.Invoke(new TestKey());

                Assert.Same(expectedValue, actualValue);
            }
        }

        public class DictionaryFuncOfTKeyTValue: IFuzzDictionaryExtensionsTest
        {
            // Method parameters
            readonly Func<TestKey> createKey = Substitute.For<Func<TestKey>>();
            readonly Func<TestKey, TestValue> createValue = Substitute.For<Func<TestKey, TestValue>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyDictionaryWithGivenFuzzFactoryAndCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(createKey, createValue, count);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Same(count, spec.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyDictionaryWithDefaultCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(createKey, createValue);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Equal(new Count(), spec.Field<Count>().Value);
            }

            protected override void AssertExpectedKeyFactory() =>
                Assert.Same(createKey, spec.Field<Func<TestKey>>().Value);

            protected override void AssertExpectedValueFactory() =>
                Assert.Same(createValue, spec.Field<Func<TestKey, TestValue>>().Value);
        }

        public class DictionaryIEnumerableKeyValuePair: IFuzzDictionaryExtensionsTest
        {
            // Method parameters
            readonly IReadOnlyDictionary<TestKey, TestValue> elements = new Dictionary<TestKey, TestValue>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyDictionaryWithGivenCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(elements, count);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Same(count, spec.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyDictionaryWithDefaultCount() {
                Dictionary<TestKey, TestValue> actual = fuzzy.Dictionary(elements);

                AssertExpectedFuzzyDictionary(actual);
                Assert.Equal(new Count(), spec.Field<Count>().Value);
            }

            protected override void AssertExpectedKeyFactory() {
                var expected = new KeyValuePair<TestKey, TestValue>(new TestKey(), new TestValue());
                Expression<Predicate<FuzzyElement<KeyValuePair<TestKey, TestValue>>>> fuzzyElement =
                    arg => ReferenceEquals(elements, arg.Field<IEnumerable<KeyValuePair<TestKey, TestValue>>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                TestKey actual = spec.Field<Func<TestKey>>().Value.Invoke();

                Assert.Equal(expected.Key, actual);
            }

            protected override void AssertExpectedValueFactory() {
                var expected = new KeyValuePair<TestKey, TestValue>(new TestKey(), new TestValue());
                var original = (Dictionary<TestKey, TestValue>)elements;
                original[expected.Key] = expected.Value;

                TestValue actualValue = spec.Field<Func<TestKey, TestValue>>().Value.Invoke(expected.Key);

                Assert.Same(expected.Value, actualValue);
            }
        }

        void AssertExpectedFuzzyDictionary(Dictionary<TestKey, TestValue> actual) {
            Assert.Same(expected, actual);
            Assert.Same(fuzzy, spec.Field<IFuzz>().Value);
            AssertExpectedKeyFactory();
            AssertExpectedValueFactory();
        }

        protected abstract void AssertExpectedKeyFactory();
        protected abstract void AssertExpectedValueFactory();

        public class TestKey { }
        public class TestValue { }
    }
}
