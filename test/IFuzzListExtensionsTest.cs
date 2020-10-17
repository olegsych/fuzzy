using System;
using System.Collections.Generic;
using Fuzzy.Implementation;
using Inspector;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class IFuzzListExtensionsTest
    {
        // Common method parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public class ListFuncOfT: IFuzzListExtensionsTest
        {
            // Method parameters
            readonly Func<TestItem> createElement = Substitute.For<Func<TestItem>>();
            readonly Count count = new Count();

            [Fact]
            public void ReturnsFuzzyListWithGivenFuzzFactoryAndCount() {
                Fuzzy<List<TestItem>> actual = fuzzy.List(createElement, count);

                Assert.Equal(typeof(FuzzyList<TestItem>), actual.GetType());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
                Assert.Same(createElement, actual.Field<Func<TestItem>>().Value);
                Assert.Same(count, actual.Field<Count>().Value);
            }

            [Fact]
            public void ReturnsFuzzyListWithDefaultCount() {
                Fuzzy<List<TestItem>> actual = fuzzy.List(createElement);

                Assert.Equal(typeof(FuzzyList<TestItem>), actual.GetType());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
                Assert.Same(createElement, actual.Field<Func<TestItem>>().Value);
                Assert.Equal(new Count(), actual.Field<Count>().Value);
            }
        }

        public class TestItem { }
    }
}
