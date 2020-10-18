using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyDoubleTest: FuzzyTestFixture
    {
        readonly Fuzzy<double> sut;

        public FuzzyDoubleTest() => sut = new FuzzyDouble(fuzzy);

        public class Build: FuzzyDoubleTest
        {
            [Theory]
            [InlineData(true, 1, -1076, 1 / double.PositiveInfinity)] // Positive 0
            [InlineData(true, 1, -1075, double.Epsilon)]
            [InlineData(true, 0x1FFFFFFFFFFFFF, 971, double.MaxValue)]
            [InlineData(true, 0x1FFFFFFFFFFFFF, 972, double.PositiveInfinity)]
            [InlineData(false, 1, -1076, 1 / double.NegativeInfinity)] // Negative 0
            [InlineData(false, 1, -1075, -double.Epsilon)]
            [InlineData(false, 0x1FFFFFFFFFFFFF, 971, double.MinValue)]
            [InlineData(false, 0x1FFFFFFFFFFFFF, 972, double.NegativeInfinity)]
            public void ReturnsDoubleValueComputedFromFuzzySignMantissaAndExponent(bool positive, ulong mantissa, short exponent, double expected) {
                ConfiguredCall arrange = fuzzy.Build(Arg.Any<Fuzzy<bool>>()).Returns(positive);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<ulong>>(x => x.Minimum == 1 && x.Maximum == Math.Pow(2, 53) - 1)).Returns(mantissa);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<short>>(x => x.Minimum == -1076 && x.Maximum == 972)).Returns(exponent);

                double actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
