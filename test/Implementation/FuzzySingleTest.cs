using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzySingleTest: TestFixture
    {
        readonly Fuzzy<float> sut;

        public FuzzySingleTest() => sut = new FuzzySingle(fuzzy);

        public class Build: FuzzySingleTest
        {
            public Build() => ArrangeBuildOfFuzzyInt16();

            [Theory]
            [InlineData(true, 1, -150, 1 / float.PositiveInfinity)] // Positive 0
            [InlineData(true, 1, -149, float.Epsilon)]
            [InlineData(true, 0xFFFFFF, 104, float.MaxValue)]
            [InlineData(true, 0xFFFFFF, 105, float.PositiveInfinity)]
            [InlineData(false, 1, -150, 1 / float.NegativeInfinity)] // Negative 0
            [InlineData(false, 1, -149, -float.Epsilon)]
            [InlineData(false, 0xFFFFFF, 104, float.MinValue)]
            [InlineData(false, 0xFFFFFF, 105, float.NegativeInfinity)]
            public void ReturnsSingleValueComputedFromFuzzySignMantissaAndExponent(bool positive, uint mantissa, short exponent, float expected) {
                ConfiguredCall arrange = fuzzy.Build(Arg.Any<Fuzzy<bool>>()).Returns(positive);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<uint>>(x => x.Minimum == uint.MinValue && x.Maximum == uint.MaxValue))
                    .Returns(call => {
                        var initial = (uint)random.Next();
                        FuzzyContext.Set(initial, (FuzzyRange<uint>)call[0]);
                        return initial;
                    });
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<uint>>(x => x.Minimum == 1 && x.Maximum == Math.Pow(2, 24) - 1)).Returns(mantissa);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<short>>(x => x.Minimum == -150 && x.Maximum == 105)).Returns(exponent);

                float actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
