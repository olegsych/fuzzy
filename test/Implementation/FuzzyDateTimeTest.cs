using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyDateTimeTest: FuzzyTestFixture
    {
        readonly FuzzyRange<DateTime> sut;

        public FuzzyDateTimeTest() =>
            sut = new FuzzyDateTime(fuzzy);

        public class Constructor: FuzzyDateTimeTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(DateTime.MinValue, sut.Minimum);
                Assert.Equal(DateTime.MaxValue, sut.Maximum);
            }
        }

        public class New: FuzzyDateTimeTest
        {
            [Fact]
            public void ReturnsDateTimeCreatedFromFuzzyLongAndDateTimeKindValues() {
                sut.Minimum = new DateTime(random.Next());
                sut.Maximum = new DateTime(sut.Minimum.Ticks + random.Next());
                long expectedTicks = random.Next();
                Expression<Predicate<FuzzyRange<long>>> fuzzyTicks = v => v.Minimum == sut.Minimum.Ticks && v.Maximum == sut.Maximum.Ticks;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyTicks)).Returns(expectedTicks);
                var expectedKind = (DateTimeKind)(random.Next() % ((int)DateTimeKind.Local + 1));
                arrange = fuzzy.Build(Arg.Any<FuzzyEnum<DateTimeKind>>()).Returns(expectedKind);

                DateTime actual = sut.New();

                Assert.Equal(expectedTicks, actual.Ticks);
                Assert.Equal(expectedKind, actual.Kind);
            }
        }
    }
}