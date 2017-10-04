using System;
using Xunit;

namespace Fuzzy
{
    public class RandomFuzzTest
    {
        readonly IFuzz sut;
       
        readonly int seed = new Random().Next();

        public RandomFuzzTest()
        {
            sut = new RandomFuzz(seed);
        }

        public class Consrtuctor : RandomFuzzTest
        {
            [Fact]
            public void DefaultsSeedToZero()
            {
                var expected = new RandomFuzz(0);
                var actual = new RandomFuzz();
                Assert.Equal(expected.Int32(), actual.Int32());
            }
        }

        public class Int32 : RandomFuzzTest
        {
            [Fact]
            public void ReturnsNextRandomValue()
            {
                var expected = new Random(seed);
                Assert.Equal(expected.Next(), sut.Int32());
            }
        }
    }
}
