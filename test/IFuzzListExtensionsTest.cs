using System;
using System.Collections.Generic;
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
                Fuzzy<List<TestStruct>> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                Fuzzy<List<TestStruct>> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<List<TestStruct>> fuzzyList) =>
                Assert.Same(createElement, fuzzyList.Field<Func<TestStruct>>().Value);
        }

        public class ListFuncOfFuzzyRange: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<FuzzyRange<TestStruct>> createElement = Substitute.For<Func<FuzzyRange<TestStruct>>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                Fuzzy<List<TestStruct>> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                Fuzzy<List<TestStruct>> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<List<TestStruct>> fuzzyList) {
                var min = new TestStruct(random.Next() % 1000);
                var max = new TestStruct(min.Value + random.Next() % 1000);
                var fuzzyRange = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, min, max);
                ConfiguredCall arrange1 = createElement().Returns(fuzzyRange);
                var expected = new TestStruct(random.Next());
                ConfiguredCall arrange2 = fuzzy.Build(fuzzyRange).Returns(expected);

                TestStruct actual = fuzzyList.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        void AssertExpectedFuzzyList(Fuzzy<List<TestStruct>> actual) {
            Assert.Equal(typeof(FuzzyList<TestStruct>), actual.GetType());
            Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
        }

        protected abstract void AssertExpectedFuzzyElementFactory(Fuzzy<List<TestStruct>> fuzzyList);
    }
}
