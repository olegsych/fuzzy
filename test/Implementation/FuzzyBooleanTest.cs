using System;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyBooleanTest
    {
        readonly Fuzzy<bool> sut;

        // Constructor parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        // Test fixture
        readonly Random random = new Random();

        public FuzzyBooleanTest() =>
            sut = new FuzzyBoolean(fuzzy);

        public class Constructor: FuzzyBooleanTest
        {
            [Fact]
            public void PassesFuzzyToBaseConstructor() =>
                Assert.Same(fuzzy, sut.Inherited().Field<IFuzz>().Value);
        }

        public class New: FuzzyBooleanTest
        {
            [Fact]
            public void ReturnsTrueWhenNextFuzzyValueIsOdd() {
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber());
                Assert.True(sut.New());
            }

            [Fact]
            public void ReturnsFalseWhenNextFuzzyValueIsEven() {
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber());

                Assert.False(sut.New());
            }

            int EvenNumber() {
                int value = random.Next();
                return value % 2 == 0 ? value : value + 1;
            }

            int OddNumber() {
                int value = random.Next();
                return value % 2 == 1 ? value : value + 1;
            }
        }
    }
}
