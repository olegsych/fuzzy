using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUriTest: TestFixture
    {
        readonly Fuzzy<Uri> sut;

        public FuzzyUriTest() =>
            sut = new FuzzyUri(fuzzy);

        public class Build: FuzzyUriTest
        {
            [Fact]
            public void ReturnsUriBasedOnNextFuzzyValue() {
                int number = random.Next();
                ConfiguredCall arrange = fuzzy.Number().Returns(number);

                Uri actual = sut.Build();

                Assert.Equal($"https://fuzzy{number}/", actual.ToString());
            }
        }
    }
}
