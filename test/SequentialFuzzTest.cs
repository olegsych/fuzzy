using System;
using Fuzzy.Implementation;
using Xunit;

namespace Fuzzy
{
    public class SequentialFuzzTest
    {
        readonly Fuzz sut;

        readonly int seed = new Random().Next();

        public SequentialFuzzTest() => sut = new SequentialFuzz(seed);

        public class Constructor : SequentialFuzzTest
        {
            [Fact]
            public void DefaultsSeedToZero()
            {
                var expected = new SequentialFuzz(0);
                var actual = new SequentialFuzz();
                Assert.Equal(expected.Number(), actual.Number());
            }
        }

        public class Next : SequentialFuzzTest
        {
            [Fact]
            public void ReturnIncrementedSeedValue()
            {
                Assert.Equal(seed + 1, sut.Number());
                Assert.Equal(seed + 2, sut.Number());
            }
        }
    }
}
