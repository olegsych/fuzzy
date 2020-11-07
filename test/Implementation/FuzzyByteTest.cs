using System;
using System.Linq.Expressions;
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
            [Fact]
            public void ReturnsFuzzyUInt16ValueConvertedToByte() {
                // Arrange
                sut.Minimum = (byte)(random.Next() % sbyte.MaxValue);
                sut.Maximum = (byte)(sut.Minimum + random.Next() % sbyte.MaxValue);

                ConfiguredCall arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == ushort.MinValue && s.Maximum == ushort.MaxValue))
                    .Returns(call => {
                        var initial = (ushort)(random.Next() % byte.MaxValue);
                        FuzzyContext.Set(initial, (FuzzyRange<ushort>)call[0]);
                        return initial;
                    });

                var expected = (ushort)(random.Next() % byte.MaxValue);
                arrange = fuzzy.Build(Arg.Is<FuzzyRange<ushort>>(s => s.Minimum == sut.Minimum && s.Maximum == sut.Maximum)).Returns(expected);

                // Act
                byte actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
