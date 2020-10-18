using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt64Test: FuzzyTestFixture
    {
        readonly FuzzyRange<ulong> sut;

        public FuzzyUInt64Test() =>
            sut = new FuzzyUInt64(fuzzy);

        public class Constructor: FuzzyUInt64Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(ulong.MinValue, sut.Minimum);
                Assert.Equal(ulong.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyUInt64Test
        {
            [Theory]
            [InlineData(5, 15, 0, 5)]
            [InlineData(5, 15, 5, 10)]
            [InlineData(5, 15, 10, 15)]
            [InlineData(ulong.MinValue, ulong.MaxValue, 0, ulong.MinValue)]
            [InlineData(ulong.MinValue, ulong.MaxValue, ulong.MaxValue, ulong.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(ulong minimum, ulong maximum, ulong next, ulong expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                var first = (uint)(next & 0xFFFFFFFF);
                var second = (uint)(next >> 32);
                Expression<Predicate<FuzzyRange<uint>>> unlimitedUInt32 = f => f.Minimum == uint.MinValue && f.Maximum == uint.MaxValue;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(unlimitedUInt32)).Returns(first, second);

                ulong actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
