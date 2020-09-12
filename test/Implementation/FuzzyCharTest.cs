using Inspector;
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

        public class Constructor: FuzzyCharTest
        {
            [Fact]
            public void PassesFuzzyToBaseConstructor() =>
                Assert.Same(fuzzy, sut.Inherited().Field<IFuzz>().Value);
        }

        public class New: FuzzyCharTest
        {
            [Fact]
            public void ReturnsCharValueDerivedFromNextInt32() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                char actual = sut.New();

                var expected = (char)(next % char.MaxValue);
                Assert.Equal(expected, actual);
            }
        }
    }
}
