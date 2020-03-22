using System;
using Xunit;

namespace Fuzzy
{
    public class SequentialFuzzTest
    {
        readonly IFuzz sut;

        readonly int seed = new Random().Next();

        public SequentialFuzzTest() => sut = new SequentialFuzz(seed);

        public class Constructor : SequentialFuzzTest
        {
            [Fact]
            public void DefaultsSeedToZero()
            {
                var expected = new SequentialFuzz(0);
                var actual = new SequentialFuzz();
                Assert.Equal(expected.Next(), actual.Next());
            }
        }

        public class Next : SequentialFuzzTest
        {
            [Fact]
            public void ReturnIncrementedSeedValue()
            {
                Assert.Equal(seed + 1, sut.Next());
                Assert.Equal(seed + 2, sut.Next());
            }
        }
    }
}
