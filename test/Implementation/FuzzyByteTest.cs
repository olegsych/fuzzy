using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyByteTest: FuzzyTestFixture
    {
        readonly Fuzzy<byte> sut;

        public FuzzyByteTest() =>
            sut = new FuzzyByte(fuzzy);

        public class Constructor: FuzzyByteTest
        {
            [Fact]
            public void PassesFuzzyToBaseConstructor() =>
                Assert.Same(fuzzy, sut.Inherited().Field<IFuzz>().Value);
        }

        public class New: FuzzyByteTest
        {
            [Fact]
            public void ReturnsByteValueDerivedFromNextInt32() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                byte actual = sut.New();

                var expected = (byte)(next % (byte.MaxValue + 1));
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void CanReturnMaxValue() {
                ConfiguredCall arrange = fuzzy.Next().Returns(byte.MaxValue);
                Assert.Equal(byte.MaxValue, sut.New());
            }
        }
    }
}
