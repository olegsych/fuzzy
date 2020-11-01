using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt16Test: TestFixture
    {
        readonly FuzzyRange<ushort> sut;

        public FuzzyUInt16Test() =>
            sut = new FuzzyUInt16(fuzzy);

        public class Constructor: FuzzyUInt16Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(ushort.MinValue, sut.Minimum);
                Assert.Equal(ushort.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyUInt16Test
        {
            [Theory]
            [InlineData(5, 15, 0, 5)]
            [InlineData(5, 15, 5, 10)]
            [InlineData(5, 15, 10, 15)]
            [InlineData(5, 15, -10, 15)] // In case SequentialFuzz has negative seed
            [InlineData(ushort.MinValue, ushort.MaxValue, 0, ushort.MinValue)]
            [InlineData(ushort.MinValue, ushort.MaxValue, ushort.MaxValue, ushort.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(ushort minimum, ushort maximum, int next, ushort expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                ushort actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
