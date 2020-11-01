using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUInt32Test: TestFixture
    {
        readonly FuzzyRange<uint> sut;

        public FuzzyUInt32Test() =>
            sut = new FuzzyUInt32(fuzzy);

        public class Constructor: FuzzyUInt32Test
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(uint.MinValue, sut.Minimum);
                Assert.Equal(uint.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyUInt32Test
        {
            [Theory]
            [InlineData(5, 15, 0, 5)]
            [InlineData(5, 15, 5, 10)]
            [InlineData(5, 15, 10, 15)]
            [InlineData(uint.MinValue, uint.MaxValue, 0, uint.MinValue)]
            [InlineData(uint.MinValue, uint.MaxValue, uint.MaxValue, uint.MaxValue)]
            public void CalculatesValueBasedOnMinimumMaximumAndNextSample(uint minimum, uint maximum, uint next, uint expected) {
                sut.Minimum = minimum;
                sut.Maximum = maximum;
                var first = (ushort)(next & 0xFFFF);
                var second = (ushort)(next >> 16);
                Expression<Predicate<FuzzyRange<ushort>>> unlimitedUInt16 = f => f.Minimum == ushort.MinValue && f.Maximum == ushort.MaxValue;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(unlimitedUInt16)).Returns(first, second);

                uint actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
