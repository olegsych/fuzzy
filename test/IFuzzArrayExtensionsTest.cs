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
    public abstract class IFuzzArrayExtensionsTest
    {
        static readonly Random random = new Random();

        // Common method parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public class ArrayFuncOfT: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly Func<TestStruct> createElement = Substitute.For<Func<TestStruct>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, actual.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), actual.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<TestStruct[]> fuzzyArray) =>
                Assert.Same(createElement, fuzzyArray.Field<Func<TestStruct>>().Value);
        }

        public class ArrayFuncOfFuzzyT: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly Func<Fuzzy<TestStruct>> createElement = Substitute.For<Func<Fuzzy<TestStruct>>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, actual.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), actual.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<TestStruct[]> fuzzyArray) {
                var fuzzyElement = Substitute.ForPartsOf<Fuzzy<TestStruct>>(fuzzy);
                ConfiguredCall arrange1 = createElement().Returns(fuzzyElement);
                var expected = new TestStruct(random.Next());
                ConfiguredCall arrange2 = fuzzy.Build(fuzzyElement).Returns(expected);

                TestStruct actual = fuzzyArray.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        public class ArrayFuncOfFuzzyRange: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly Func<FuzzyRange<TestStruct>> createElement = Substitute.For<Func<FuzzyRange<TestStruct>>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, actual.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(createElement);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), actual.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<TestStruct[]> fuzzyArray) {
                var min = new TestStruct(random.Next() % 1000);
                var max = new TestStruct(min.Value + random.Next() % 1000);
                var fuzzyElement = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzzy, min, max);
                ConfiguredCall arrange1 = createElement().Returns(fuzzyElement);
                var expected = new TestStruct(random.Next());
                ConfiguredCall arrange2 = fuzzy.Build(fuzzyElement).Returns(expected);

                TestStruct actual = fuzzyArray.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        public class ArrayIEnumerableT: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly IEnumerable<TestStruct> elements = Substitute.For<IEnumerable<TestStruct>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(elements, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, actual.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                Fuzzy<TestStruct[]> actual = fuzzy.Array(elements);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), actual.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory(Fuzzy<TestStruct[]> fuzzyArray) {
                var expected = new TestStruct(random.Next());
                Expression<Predicate<FuzzyElement<TestStruct>>> fuzzyElement = f => ReferenceEquals(elements, f.Field<IEnumerable<TestStruct>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                TestStruct actual = fuzzyArray.Field<Func<TestStruct>>().Value();

                Assert.Equal(expected, actual);
            }
        }

        void AssertExpectedFuzzyArray(Fuzzy<TestStruct[]> fuzzyArray) {
            Assert.Equal(typeof(FuzzyArray<TestStruct>), fuzzyArray.GetType());
            Assert.Same(fuzzy, fuzzyArray.Field<IFuzz>().Value);
            AssertExpectedFuzzyElementFactory(fuzzyArray);
        }

        protected abstract void AssertExpectedFuzzyElementFactory(Fuzzy<TestStruct[]> fuzzyArray);
    }
}