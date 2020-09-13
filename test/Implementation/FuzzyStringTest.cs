using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyStringTest: FuzzyTestFixture
    {
        readonly Fuzzy<string> sut;

        public FuzzyStringTest() =>
            sut = new FuzzyString(fuzzy);

        public class New: FuzzyStringTest
        {
            [Fact]
            public void ReturnsStringBasedOnNextFuzzyValue() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                string actual = sut.New();

                Assert.Equal($"fuzzy{next}", actual);
            }
        }
    }
}
