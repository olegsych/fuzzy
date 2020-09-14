using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt64Test: FuzzyTestFixture
    {
        readonly Fuzzy<ulong> sut;

        public FuzzyUInt64Test() =>
            sut = new FuzzyUInt64(fuzzy);

        public class New: FuzzyUInt64Test
        {
            [Fact]
            public void ReturnsUInt64CalculatedByMultiplyingTwoUInt32Values() {
                var first = (uint)random.Next() | 0x80000000;
                var second = (uint)random.Next() | 0x80000000;
                ConfiguredCall arrange = fuzzy.Build(Arg.Any<Fuzzy<uint>>()).Returns(first, second);

                ulong actual = sut.New();

                ulong expected = first * second;
                Assert.Equal(expected, actual);
            }
        }
    }
}
