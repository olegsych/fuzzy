using System;
using Xunit;

namespace Fuzzy
{
    public class NaturalRangeTest
    {
        readonly NaturalRange sut = NaturalRange.Min(42);

        static readonly Random random = new Random();

        public class Between : NaturalRangeTest
        {
            readonly int max = Math.Abs(random.Next());

            [Fact]
            public void ThrowsDescriptiveExceptionWhenMinIsLessThan0()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => NaturalRange.Between(-1, max));
            }
        }

        public class Min : NaturalRangeTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsLessThan0()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => NaturalRange.Min(-1));
            }
        }
    }
}
