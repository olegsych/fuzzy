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
    public class FuzzyIEnumerableTest
    {
        readonly Fuzzy<IEnumerable<TestItem>> sut;

        // Constructor parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();
        readonly Func<TestItem> itemFactory = Substitute.For<Func<TestItem>>();
        readonly Count itemCount;

        // Test fixture
        static readonly Random random = new Random();
        readonly int minCount;
        readonly int maxCount;

        FuzzyIEnumerableTest() {
            minCount = 1 + random.Next() % 10;
            maxCount = minCount + 1 + random.Next() % 10;
            itemCount = Count.Between(minCount, maxCount);
            sut = new FuzzyIEnumerable<TestItem>(fuzzy, itemFactory, itemCount);
        }

        public class Constructor: FuzzyIEnumerableTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyIEnumerable<TestItem>(null, itemFactory, itemCount));
                Assert.Equal(sut.Constructor().Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenItemFactoryIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyIEnumerable<TestItem>(fuzzy, null, itemCount));
                Assert.Equal(sut.Constructor().Parameter<Func<TestItem>>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenItemCountIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyIEnumerable<TestItem>(fuzzy, itemFactory, null));
                Assert.Equal(sut.Constructor().Parameter<Count>().Name, thrown.ParamName);
            }
        }

        public class New: FuzzyIEnumerableTest
        {
            [Fact]
            public void ReturnsIEnumerableWithGivenCountOfItemsCreatedByFactory() {
                int expectedCount = 2 + random.Next() % 10;
                Expression<Predicate<FuzzyRange<int>>> fuzzyCount = f => f.Minimum == minCount && f.Maximum == maxCount;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyCount)).Returns(expectedCount);
                IEnumerable<TestItem> expectedItems = Enumerable.Range(0, expectedCount).Select(i => new TestItem()).ToArray();
                arrange = itemFactory.Invoke().Returns(expectedItems.First(), expectedItems.Skip(1).ToArray());

                IEnumerable<TestItem> actualItems = sut.New();

                Assert.Equal(expectedItems, actualItems);
            }
        }

        public class TestItem { }
    }
}
