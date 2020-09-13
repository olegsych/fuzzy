using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt64Test: FuzzyTestFixture
    {
        readonly Fuzzy<long> sut;

        public FuzzyInt64Test() =>
            sut = new FuzzyInt64(fuzzy);

        public class New: FuzzyInt64Test
        {
            [Fact]
            public void ReturnsInt64CalculatedFromInt32MultipliedByUInt32() {
                int fuzzyInt32 = random.Next();
                var fuzzyUInt32 = (uint)random.Next() | 0x80000000;
                ConfiguredCall arrange;
                arrange = fuzzy.GetValue(Arg.Any<Fuzzy<int>>()).Returns(fuzzyInt32);
                arrange = fuzzy.GetValue(Arg.Any<Fuzzy<uint>>()).Returns(fuzzyUInt32);

                long actual = sut.New();

                long expected = fuzzyInt32 * fuzzyUInt32;
                Assert.Equal(expected, actual);
            }
        }
    }
}
