using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt32Test: FuzzyTestFixture
    {
        readonly Fuzzy<uint> sut;

        public FuzzyUInt32Test() =>
            sut = new FuzzyUInt32(fuzzy);

        public class New: FuzzyUInt32Test
        {
            [Fact]
            public void ReturnsFuzzyValueWithinInt32RangeWhenFirstNumberIsEven() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber(), next);

                uint actual = sut.New();

                var expected = (uint)next;
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ReturnsFuzzyValueOutsideOfInt32RangeWhenFirstNumberIsOdd() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber(), next);

                uint actual = sut.New();

                var expected = (uint)next | 0x80000000;
                Assert.Equal(expected, actual);
            }
        }
    }
}
