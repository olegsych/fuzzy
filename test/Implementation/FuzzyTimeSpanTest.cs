using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyTimeSpanTest: TestFixture
    {
        readonly FuzzyRange<TimeSpan> sut;

        public FuzzyTimeSpanTest() =>
            sut = new FuzzyTimeSpan(fuzzy);

        public class Constructor: FuzzyTimeSpanTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(TimeSpan.MinValue, sut.Minimum);
                Assert.Equal(TimeSpan.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyTimeSpanTest
        {
            public Build() => ArrangeBuildOfFuzzyInt64();

            [Fact]
            public void ReturnsTimeSpanCreatedFromInt64() {
                sut.Minimum = new TimeSpan(long.MinValue + random.Next());
                sut.Maximum = new TimeSpan(long.MaxValue - random.Next());
                var expected = new TimeSpan(random.Next());
                Expression<Predicate<FuzzyRange<long>>> fuzzyInt64 = v => v.Minimum == sut.Minimum.Ticks && v.Maximum == sut.Maximum.Ticks;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyInt64)).Returns(expected.Ticks);

                TimeSpan actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
