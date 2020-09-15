using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyTimeSpanTest: FuzzyTestFixture
    {
        readonly Fuzzy<TimeSpan> sut;

        public FuzzyTimeSpanTest() =>
            sut = new FuzzyTimeSpan(fuzzy);

        public class New: FuzzyTimeSpanTest
        {
            [Fact]
            public void ReturnsTimeSpanCreatedFromInt64() {
                var ticks = (long)int.MaxValue * random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Any<Fuzzy<long>>()).Returns(ticks);

                TimeSpan actual = sut.New();

                var expected = new TimeSpan(ticks);
                Assert.Equal(expected, actual);
            }
        }
    }
}
