using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyCharTest: FuzzyTestFixture
    {
        readonly Fuzzy<char> sut;

        public FuzzyCharTest() =>
            sut = new FuzzyChar(fuzzy);

        public class New: FuzzyCharTest
        {
            [Fact]
            public void ReturnsCharValueDerivedFromNextInt32() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                char actual = sut.New();

                var expected = (char)(next % (char.MaxValue + 1));
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void CanReturnMaxValue() {
                ConfiguredCall arrange = fuzzy.Next().Returns(char.MaxValue);
                Assert.Equal(char.MaxValue, sut.New());
            }
        }
    }
}
