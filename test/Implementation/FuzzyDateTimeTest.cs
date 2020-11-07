using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyDateTimeTest: TestFixture
    {
        readonly FuzzyRange<DateTime> sut;

        // Constructor parameters
        readonly DateTimeKind? kind = null;

        public FuzzyDateTimeTest() =>
            sut = new FuzzyDateTime(fuzzy, kind);

        public class Constructor: FuzzyDateTimeTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(DateTime.MinValue, sut.Minimum);
                Assert.Equal(DateTime.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzyDateTimeTest
        {
            public Build() => ArrangeBuildOfFuzzyInt64();

            [Fact]
            public void ReturnsDateTimeCreatedFromFuzzyLongAndDateTimeKindValues() {
                sut.Minimum = new DateTime(random.Next());
                sut.Maximum = new DateTime(sut.Minimum.Ticks + random.Next());
                long expectedTicks = random.Next();
                Expression<Predicate<FuzzyRange<long>>> fuzzyTicks = v => v.Minimum == sut.Minimum.Ticks && v.Maximum == sut.Maximum.Ticks;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyTicks)).Returns(expectedTicks);
                var expectedKind = (DateTimeKind)(random.Next() % ((int)DateTimeKind.Local + 1));
                arrange = fuzzy.Build(Arg.Any<FuzzyEnum<DateTimeKind>>()).Returns(expectedKind);

                DateTime actual = sut.Build();

                Assert.Equal(expectedTicks, actual.Ticks);
                Assert.Equal(expectedKind, actual.Kind);
            }


            [Fact]
            public void ReturnsDateTimeCreatedFromFuzzyLongAndGivenDateTimeKindValues() {
                var expectedKind = (DateTimeKind)(random.Next() % ((int)DateTimeKind.Local + 1));
                var sut = new FuzzyDateTime(fuzzy, expectedKind);
                sut.Minimum = new DateTime(random.Next());
                sut.Maximum = new DateTime(sut.Minimum.Ticks + random.Next());
                long expectedTicks = random.Next();
                Expression<Predicate<FuzzyRange<long>>> fuzzyTicks = v => v.Minimum == sut.Minimum.Ticks && v.Maximum == sut.Maximum.Ticks;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyTicks)).Returns(expectedTicks);

                DateTime actual = sut.Build();

                Assert.Equal(expectedTicks, actual.Ticks);
                Assert.Equal(expectedKind, actual.Kind);
                DateTimeKind assert = fuzzy.DidNotReceive().Build(Arg.Any<FuzzyEnum<DateTimeKind>>());
            }
        }
    }
}
