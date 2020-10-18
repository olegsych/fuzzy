using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyInt64Test: FuzzyTestFixture
    {
        readonly FuzzyRange<long> sut;

        public FuzzyInt64Test() =>
            sut = new FuzzyInt64(fuzzy);

        public class Constructor: FuzzyInt64Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(long.MinValue, sut.Minimum);
                Assert.Equal(long.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyInt64Test
        {
            [Theory]
            [InlineData(-5, 5, 0, -5)]
            [InlineData(-5, 5, 5, 0)]
            [InlineData(-5, 5, 10, 5)]
            [InlineData(long.MinValue, long.MaxValue, 0, long.MinValue)]
            [InlineData(long.MinValue, long.MaxValue, (ulong)long.MaxValue + 1, 0)]
            [InlineData(long.MinValue, long.MaxValue, ulong.MaxValue, long.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(long minimum, long maximum, ulong sample, long expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                Expression<Predicate<FuzzyRange<ulong>>> unlimitedUInt64 = f => f.Minimum == ulong.MinValue && f.Maximum == ulong.MaxValue;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(unlimitedUInt64)).Returns(sample);

                long actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
