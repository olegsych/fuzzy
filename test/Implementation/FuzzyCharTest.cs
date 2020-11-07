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
            public Build() => ArrangeBuildOfFuzzyUInt16();

            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToChar() {
                sut.Minimum = (char)(random.Next() % byte.MaxValue);
                sut.Maximum = (char)(sut.Minimum + random.Next() % byte.MaxValue);
                ushort expected = (ushort)(random.Next() % char.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == sut.Minimum && s.Maximum == sut.Maximum)).Returns(expected);

                char actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
