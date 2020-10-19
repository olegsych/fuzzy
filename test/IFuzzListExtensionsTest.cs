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
    public abstract class IFuzzListExtensionsTest
    {
        static readonly Random random = new Random();

        // Common method parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public class ListFuncOfT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<TestStruct> createElement = Substitute.For<Func<TestStruct>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(FuzzyList<TestStruct> fuzzyList) =>
                Assert.Same(createElement, fuzzyList.Field<Func<TestStruct>>().Value);
        }

        public class ListFuncOfFuzzyT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<Fuzzy<TestStruct>> createElement = Substitute.For<Func<Fuzzy<TestStruct>>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(FuzzyList<TestStruct> fuzzyList) {
                var fuzzyElement = Substitute.ForPartsOf<Fuzzy<TestStruct>>(fuzzy);
                ConfiguredCall arrange1 = createElement().Returns(fuzzyElement);
                var expected = new TestStruct(random.Next());
                ConfiguredCall arrange2 = fuzzy.Build(fuzzyElement).Returns(expected);

                TestStruct actual = fuzzyList.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        public class ListFuncOfFuzzyRange: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<FuzzyRange<TestStruct>> createElement = Substitute.For<Func<FuzzyRange<TestStruct>>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(FuzzyList<TestStruct> fuzzyList) {
                var min = new TestStruct(random.Next() % 1000);
                var max = new TestStruct(min.Value + random.Next() % 1000);
                var fuzzyElement = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, min, max);
                ConfiguredCall arrange1 = createElement().Returns(fuzzyElement);
                var expected = new TestStruct(random.Next());
                ConfiguredCall arrange2 = fuzzy.Build(fuzzyElement).Returns(expected);

                TestStruct actual = fuzzyList.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        public class ListIEnumerableT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly IEnumerable<TestStruct> elements = Substitute.For<IEnumerable<TestStruct>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(elements, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                FuzzyList<TestStruct> actual = fuzzy.List(elements);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(FuzzyList<TestStruct> fuzzyList) {
                var expected = new TestStruct(random.Next());
                Expression<Predicate<FuzzyElement<TestStruct>>> fuzzyElement = f => ReferenceEquals(elements, f.Field<IEnumerable<TestStruct>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                TestStruct actual = fuzzyList.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        void AssertExpectedFuzzyList(FuzzyList<TestStruct> fuzzyList) {
            Assert.Equal(typeof(FuzzyList<TestStruct>), fuzzyList.GetType());
            Assert.Same(fuzzy, fuzzyList.Field<IFuzz>().Value);
            AssertExpectedFuzzyElementFactory(fuzzyList);
        }

        protected abstract void AssertExpectedFuzzyElementFactory(FuzzyList<TestStruct> fuzzyList);
    }
}
