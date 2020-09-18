using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyCharTest: FuzzyTestFixture
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

        public class New: FuzzyCharTest
        {
            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToChar() {
                sut.Minimum = (char)(random.Next() % byte.MaxValue);
                sut.Maximum = (char)(sut.Minimum + random.Next() % byte.MaxValue);
                ushort expected = (ushort)(random.Next() % ushort.MaxValue);
                Expression<Predicate<FuzzyRange<ushort>>> fuzzyUInt16 = v => v.Minimum == sut.Minimum && v.Maximum == sut.Maximum;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyUInt16)).Returns(expected);

                char actual = sut.New();

                Assert.Equal(expected, actual);
            }
        }
    }
}
