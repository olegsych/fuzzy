using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt16Test: FuzzyTestFixture
    {
        readonly Fuzzy<short> sut;

        public FuzzyInt16Test() =>
            sut = new FuzzyInt16(fuzzy);

        public class New: FuzzyInt16Test
        {
            [Fact]
            public void ReturnsPositiveFuzzyValueWhenFirstNumberIsEven() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber(), next);

                short actual = sut.New();

                var expected = (short)(next % (short.MaxValue + 1));
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ReturnsNegativeFuzzyValueWhenFirstNumberIsOdd() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber(), next);

                short actual = sut.New();

                var expected = (short)(-next % (short.MaxValue + 1));
                Assert.Equal(expected, actual);
            }
        }
    }
}
