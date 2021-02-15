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
    public abstract class IFuzzListExtensionsTest: TestFixture
    {
        // Test fixture
        readonly List<TestStruct> expected = new List<TestStruct>();
        FuzzyList<TestStruct>? spec;

        public IFuzzListExtensionsTest() {
            ConfiguredCall unused = fuzzy.Build(Arg.Do<FuzzyList<TestStruct>>(s => spec = s)).Returns(expected);
        }

        public class ListFuncOfT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<TestStruct> createElement = Substitute.For<Func<TestStruct>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                List<TestStruct> actual = fuzzy.List(createElement, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, spec!.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                List<TestStruct> actual = fuzzy.List(createElement);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), spec!.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory() =>
                Assert.Same(createElement, spec!.Field<Func<TestStruct>>().Value);
        }

        public class ListIEnumerableT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly IEnumerable<TestStruct> elements = Substitute.For<IEnumerable<TestStruct>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                List<TestStruct> actual = fuzzy.List(elements, count);

                AssertExpectedFuzzyList(actual);
                Assert.Same(count, spec!.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                List<TestStruct> actual = fuzzy.List(elements);

                AssertExpectedFuzzyList(actual);
                Assert.Equal(new Count(), spec!.Field<Count>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory() {
                var expected = new TestStruct(random.Next());
                Expression<Predicate<FuzzyElement<TestStruct>>> fuzzyElement = f => ReferenceEquals(elements, f.Field<IEnumerable<TestStruct>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                TestStruct actual = spec!.Field<Func<TestStruct>>().Value!();

                Assert.Equal(expected, actual);
            }
        }

        void AssertExpectedFuzzyList(List<TestStruct> actual) {
            Assert.Same(expected, actual);
            Assert.Equal(typeof(FuzzyList<TestStruct>), spec!.GetType());
            Assert.Same(fuzzy, spec.Field<IFuzz>().Value);
            AssertExpectedFuzzyElementFactory();
        }

        protected abstract void AssertExpectedFuzzyElementFactory();
    }
}
