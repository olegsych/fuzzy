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
    public abstract class IFuzzArrayExtensionsTest: TestFixture
    {
        // Test fixture
        readonly TestStruct[] expected = new TestStruct[0];
        FuzzyArray<TestStruct>? spec;

        public IFuzzArrayExtensionsTest() {
            ConfiguredCall unused = fuzzy.Build(Arg.Do<FuzzyArray<TestStruct>>(s => spec = s)).Returns(expected);
        }

        public class ArrayFuncOfT: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly Func<TestStruct> createElement = Substitute.For<Func<TestStruct>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                TestStruct[] actual = fuzzy.Array(createElement, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, spec!.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                TestStruct[] actual = fuzzy.Array(createElement);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), spec!.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory() =>
                Assert.Same(createElement, spec!.Field<Func<TestStruct>>().Value);
        }

        public class ArrayIEnumerableT: IFuzzArrayExtensionsTest
        {
            // Method parameters
            readonly IEnumerable<TestStruct> elements = Substitute.For<IEnumerable<TestStruct>>();
            readonly Length length = new Length();

            [Fact]
            public void ReturnsFuzzyArrayWithGivenFuzzFactoryAndLength() {
                TestStruct[] actual = fuzzy.Array(elements, length);

                AssertExpectedFuzzyArray(actual);
                Assert.Same(length, spec!.Field<Length>().Value);
            }

            [Fact]
            public void ReturnsFuzzyArrayWithDefaultLength() {
                TestStruct[] actual = fuzzy.Array(elements);

                AssertExpectedFuzzyArray(actual);
                Assert.Equal(new Length(), spec!.Field<Length>().Value);
            }

            protected override void AssertExpectedFuzzyElementFactory() {
                var expected = new TestStruct(random.Next());
                Expression<Predicate<FuzzyElement<TestStruct>>> fuzzyElement = f => ReferenceEquals(elements, f.Field<IEnumerable<TestStruct>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                TestStruct actual = spec!.Field<Func<TestStruct>>().Value!();

                Assert.Equal(expected, actual);
            }
        }

        void AssertExpectedFuzzyArray(TestStruct[] actual) {
            Assert.Same(expected, actual);
            Assert.Same(fuzzy, spec!.Field<IFuzz>().Value);
            AssertExpectedFuzzyElementFactory();
        }

        protected abstract void AssertExpectedFuzzyElementFactory();
    }
}
