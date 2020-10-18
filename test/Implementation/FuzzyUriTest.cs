using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyUriTest: FuzzyTestFixture
    {
        readonly Fuzzy<Uri> sut;

        public FuzzyUriTest() =>
            sut = new FuzzyUri(fuzzy);

        public class Build: FuzzyUriTest
        {
            [Fact]
            public void ReturnsUriBasedOnNextFuzzyValue() {
                int next = random.Next();
                ConfiguredCall arrange = fuzzy.Next().Returns(next);

                Uri actual = sut.Build();

                Assert.Equal($"https://fuzzy{next}/", actual.ToString());
            }
        }
    }
}
