using System;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt32Test
    {
        readonly Fuzzy<int> sut;

        // Constructor parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        // Test fixture
        readonly Random random = new Random();

        public FuzzyInt32Test() =>
            sut = new FuzzyInt32(fuzzy);

        public class Constructor: FuzzyInt32Test
        {
            [Fact]
            public void PassesFuzzyToBaseConstructor() =>
                Assert.Same(fuzzy, sut.Inherited().Field<IFuzz>().Value);
        }

        public class New: FuzzyInt32Test
        {
            [Fact]
            public void ReturnsPositiveFuzzyValueWhenFirstNumberIsEven() {
                int expected = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber(), expected);

                int actual = sut.New();

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ReturnsNegativeFuzzyValueWhenFirstNumberIsOdd() {
                int expected = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber(), expected);

                int actual = sut.New();

                Assert.Equal(-expected, actual);
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
