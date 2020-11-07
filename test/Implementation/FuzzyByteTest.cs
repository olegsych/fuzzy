using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyByteTest: TestFixture
    {
        readonly FuzzyRange<byte> sut;

        public FuzzyByteTest() =>
            sut = new FuzzyByte(fuzzy);

        public class Constructor: FuzzyByteTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(byte.MinValue, sut.Minimum);
                Assert.Equal(byte.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyByteTest
        {
            public Build() => ArrangeBuildOfFuzzyUInt16();

            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToByte() {
                sut.Minimum = (byte)(random.Next() % sbyte.MaxValue);
                sut.Maximum = (byte)(sut.Minimum + random.Next() % sbyte.MaxValue);
                var expected = (ushort)(random.Next() % byte.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == sut.Minimum && s.Maximum == sut.Maximum)).Returns(expected);

                byte actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
