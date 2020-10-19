using System;
using System.Linq;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyArrayTest
    {
        readonly FuzzyCollection<TestStruct[], TestStruct> sut;

        // Constructor parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();
        readonly Func<TestStruct> itemFactory = Substitute.For<Func<TestStruct>>();
        readonly Length length;

        // Test fixture
        static readonly Random random = new Random();
        readonly int minLength;
        readonly int maxLength;

        FuzzyArrayTest() {
            minLength = 1 + random.Next() % 10;
            maxLength = minLength + 1 + random.Next() % 10;
            length = Length.Between(minLength, maxLength);
            sut = new FuzzyArray<TestStruct>(fuzzy, itemFactory, length);
        }

        public class Constructor: FuzzyArrayTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyArray<TestStruct>(null, itemFactory, length));
                Assert.Equal(sut.Constructor().Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenItemFactoryIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyArray<TestStruct>(fuzzy, null, length));
                Assert.Equal(sut.Constructor().Parameter<Func<TestStruct>>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenLengthIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyArray<TestStruct>(fuzzy, itemFactory, null));
                Assert.Equal(sut.Constructor().Parameter<Length>().Name, thrown.ParamName);
            }
        }

        public class Build: FuzzyArrayTest
        {
            [Fact]
            public void ReturnsArrayWithGivenLengthAndItemsCreatedByFactory() {
                int expectedLength = 2 + random.Next() % 10;
                Expression<Predicate<FuzzyRange<int>>> fuzzyLength = f => f.Minimum == minLength && f.Maximum == maxLength;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyLength)).Returns(expectedLength);
                TestStruct[] expectedItems = Enumerable.Range(0, expectedLength).Select(i => new TestStruct()).ToArray();
                arrange = itemFactory.Invoke().Returns(expectedItems.First(), expectedItems.Skip(1).ToArray());

                TestStruct[] actualItems = sut.Build();

                Assert.Equal(expectedItems, actualItems);
            }
        }
    }
}
