using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt32Test: FuzzyTestFixture
    {
        readonly FuzzyRange<int> sut;

        public FuzzyInt32Test() =>
            sut = new FuzzyInt32(fuzzy);

        public class Constructor: FuzzyInt32Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(int.MinValue, sut.Minimum);
                Assert.Equal(int.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyInt32Test
        {
            [Theory]
            [InlineData(-5, 5, 0, -5)]
            [InlineData(-5, 5, 5, 0)]
            [InlineData(-5, 5, 10, 5)]
            [InlineData(int.MinValue, int.MaxValue, 0, int.MinValue)]
            [InlineData(int.MinValue, int.MaxValue, uint.MaxValue, int.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(int minimum, int maximum, uint sample, int expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                Expression<Predicate<FuzzyRange<uint>>> unlimitedUInt32 = f => f.Minimum == uint.MinValue && f.Maximum == uint.MaxValue;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(unlimitedUInt32)).Returns(sample);

                int actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
