using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyBooleanTest: TestFixture
    {
        readonly Fuzzy<bool> sut;

        public FuzzyBooleanTest() =>
            sut = new FuzzyBoolean(fuzzy);

        public class Build: FuzzyBooleanTest
        {
            [Fact]
            public void ReturnsTrueWhenNextFuzzyValueIsOdd() {
                ConfiguredCall arrange = fuzzy.Number().Returns(OddNumber());
                Assert.True(sut.Build());
            }

            [Fact]
            public void ReturnsFalseWhenNextFuzzyValueIsEven() {
                ConfiguredCall arrange = fuzzy.Number().Returns(EvenNumber());
                Assert.False(sut.Build());
            }
        }

        int EvenNumber() {
            int value = random.Next();
            return value % 2 == 0 ? value : value + 1;
        }

        int OddNumber() {
            int value = random.Next();
            return value % 2 == 1 ? value : value + 1;
        }
    }
}
