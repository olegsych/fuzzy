using System;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt16Test: TestFixture
    {
        readonly FuzzyRange<short> sut;

        public FuzzyInt16Test() =>
            sut = new FuzzyInt16(fuzzy);

        public class Constructor: FuzzyInt16Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(short.MinValue, sut.Minimum);
                Assert.Equal(short.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyInt16Test
        {
            [Theory]
            [InlineData(-5, 5, 0, -5)]
            [InlineData(-5, 5, 5, 0)]
            [InlineData(-5, 5, 10, 5)]
            [InlineData(-5, 5, -10, 5)] // In case SequentialFuzz has negative seed
            [InlineData(short.MinValue, short.MaxValue, 0, short.MinValue)]
            [InlineData(short.MinValue, short.MaxValue, ushort.MaxValue, short.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(short minimum, short maximum, int next, short expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                short actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
