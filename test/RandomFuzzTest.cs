using System;
using Fuzzy.Implementation;
using Xunit;

namespace Fuzzy
{
    public class RandomFuzzTest
    {
        readonly Fuzz sut;

        readonly int seed = new Random().Next();

        public RandomFuzzTest() => sut = new RandomFuzz(seed);

        public class Consrtuctor : RandomFuzzTest
        {
            [Fact]
            public void DefaultsSeedToZero()
            {
                var expected = new RandomFuzz(0);
                var actual = new RandomFuzz();
                Assert.Equal(expected.Next(), actual.Next());
            }
        }

        public class Next : RandomFuzzTest
        {
            [Fact]
            public void ReturnsNextRandomValue()
            {
                var expected = new Random(seed);
                Assert.Equal(expected.Next(), sut.Next());
            }
        }
    }
}
