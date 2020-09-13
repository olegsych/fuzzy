using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt16Test: FuzzyTestFixture
    {
        readonly Fuzzy<ushort> sut;

        public FuzzyUInt16Test() =>
            sut = new FuzzyUInt16(fuzzy);

        public class New: FuzzyUInt16Test
        {
            [Fact]
            public void ReturnsUInt16ValueDerivedFromNextInt32() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                ushort actual = sut.New();

                var expected = (ushort)(next % (ushort.MaxValue + 1));
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void CanReturnMaxValue() {
                ConfiguredCall arrange = fuzzy.Next().Returns(ushort.MaxValue);
                Assert.Equal(ushort.MaxValue, sut.New());
            }
        }
    }
}
