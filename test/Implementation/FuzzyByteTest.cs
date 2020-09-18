using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyByteTest: FuzzyTestFixture
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

        public class New: FuzzyByteTest
        {
            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToByte() {
                sut.Minimum = (byte)(random.Next() % sbyte.MaxValue);
                sut.Maximum = (byte)(sut.Minimum + random.Next() % sbyte.MaxValue);
                var expected = (ushort)(random.Next() % byte.MaxValue);
                Expression<Predicate<FuzzyRange<ushort>>> fuzzyUInt16 = v => v.Minimum == sut.Minimum && v.Maximum == sut.Maximum;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyUInt16)).Returns(expected);

                byte actual = sut.New();

                Assert.Equal(expected, actual);
            }
        }
    }
}
