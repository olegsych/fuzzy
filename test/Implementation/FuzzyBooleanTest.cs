using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyBooleanTest: FuzzyTestFixture
    {
        readonly Fuzzy<bool> sut;

        public FuzzyBooleanTest() =>
            sut = new FuzzyBoolean(fuzzy);

        public class New: FuzzyBooleanTest
        {
            [Fact]
            public void ReturnsTrueWhenNextFuzzyValueIsOdd() {
                ConfiguredCall arrange = fuzzy.Next().Returns(OddNumber());
                Assert.True(sut.New());
            }

            [Fact]
            public void ReturnsFalseWhenNextFuzzyValueIsEven() {
                ConfiguredCall arrange = fuzzy.Next().Returns(EvenNumber());
                Assert.False(sut.New());
            }
        }
    }
}
