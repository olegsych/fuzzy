using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyCharTest: TestFixture
    {
        readonly FuzzyRange<char> sut;

        public FuzzyCharTest() =>
            sut = new FuzzyChar(fuzzy);

        public class Constructor: FuzzyCharTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(char.MinValue, sut.Minimum);
                Assert.Equal(char.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyCharTest
        {
            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToChar() {
                // Arrange
                sut.Minimum = (char)(random.Next() % byte.MaxValue);
                sut.Maximum = (char)(sut.Minimum + random.Next() % byte.MaxValue);

                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == ushort.MinValue && s.Maximum == ushort.MaxValue))
                    .Returns(call => {
                        var initial = (ushort)(random.Next() % byte.MaxValue);
                        FuzzyContext.Set(initial, (FuzzyRange<ushort>)call[0]);
                        return initial;
                    });

                ushort expected = (ushort)(random.Next() % ushort.MaxValue);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == sut.Minimum && s.Maximum == sut.Maximum)).Returns(expected);

                // Act
                char actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
