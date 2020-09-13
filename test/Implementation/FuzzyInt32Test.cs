using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt32Test: FuzzyTestFixture
    {
        readonly Fuzzy<int> sut;

        public FuzzyInt32Test() =>
            sut = new FuzzyInt32(fuzzy);

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
        }
    }
}
