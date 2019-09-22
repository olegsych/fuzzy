using System;
using Xunit;

namespace Fuzzy
{
    public class NaturalRangeTest
    {
        static readonly Random random = new Random();

        public class Between : NaturalRangeTest
        {
            readonly int max = Math.Abs(random.Next());

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMinIsLessThan0() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => TestRange.Between(-1, max));
        }

        public class Min : NaturalRangeTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0() =>
                Assert.Throws<ArgumentOutOfRangeException>(() => TestRange.Min(-1));
        }

        class TestRange : NaturalRange<TestRange> {}
    }
}
