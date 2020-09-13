using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzySByteTest: FuzzyTestFixture
    {
        readonly Fuzzy<sbyte> sut;

        public FuzzySByteTest() =>
            sut = new FuzzySByte(fuzzy);

        public class New: FuzzySByteTest
        {
            [Fact]
            public void ReturnsPositiveFuzzyValueWhenFirstNumberIsEven() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber(), next);

                sbyte actual = sut.New();

                var expected = (sbyte)(next % (sbyte.MaxValue + 1));
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ReturnsNegativeFuzzyValueWhenFirstNumberIsOdd() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber(), next);

                sbyte actual = sut.New();

                var expected = (sbyte)(-next % (sbyte.MaxValue + 1));
                Assert.Equal(expected, actual);
            }
        }
    }
}
