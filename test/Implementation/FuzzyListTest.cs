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
    public class FuzzyListTest: TestFixture
    {
        readonly Fuzzy<List<TestItem>> sut;

        // Constructor parameters
        readonly Func<TestItem> itemFactory = Substitute.For<Func<TestItem>>();
        readonly Count itemCount;

        // Test fixture
        readonly int minCount;
        readonly int maxCount;

        FuzzyListTest() {
            minCount = 1 + random.Next() % 10;
            maxCount = minCount + 1 + random.Next() % 10;
            itemCount = Count.Between(minCount, maxCount);
            sut = new FuzzyList<TestItem>(fuzzy, itemFactory, itemCount);
        }

        public class Constructor: FuzzyListTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyList<TestItem>(null, itemFactory, itemCount));
                Assert.Equal(sut.Constructor().Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenItemFactoryIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyList<TestItem>(fuzzy, null, itemCount));
                Assert.Equal(sut.Constructor().Parameter<Func<TestItem>>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenItemCountIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyList<TestItem>(fuzzy, itemFactory, null));
                Assert.Equal(sut.Constructor().Parameter<Count>().Name, thrown.ParamName);
            }
        }

        public class Build: FuzzyListTest
        {
            public Build() => ArrangeBuildOfFuzzyInt32();

            [Fact]
            public void ReturnsListWithGivenCountOfItemsCreatedByFactory() {
                int expectedCount = 2 + random.Next() % 10;
                Expression<Predicate<FuzzyRange<int>>> fuzzyCount = f => f.Minimum == minCount && f.Maximum == maxCount;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyCount)).Returns(expectedCount);
                List<TestItem> expectedItems = Enumerable.Range(0, expectedCount).Select(i => new TestItem()).ToList();
                arrange = itemFactory.Invoke().Returns(expectedItems.First(), expectedItems.Skip(1).ToArray());

                List<TestItem> actualItems = sut.Build();

                Assert.Equal(expectedItems, actualItems);
            }
        }

        public class TestItem { }
    }
}
