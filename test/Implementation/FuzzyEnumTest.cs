using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public partial class FuzzyEnumTest: FuzzyTestFixture
    {
        readonly Fuzzy<TestEnum> sut;

        public FuzzyEnumTest() => sut = new FuzzyEnum<TestEnum>(fuzzy);

        public class Constructor: FuzzyEnumTest
        {
            [Fact]
            public void InitializesBaseClass() =>
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
        }

        public class New: FuzzyEnumTest
        {
            [Fact]
            public void ReturnsFuzzyElementOfEnumValues() {
                var expected = (TestEnum)random.Next();
                Expression<Predicate<FuzzyElement<TestEnum>>> fuzzyEnumElement =
                    f => Enum.GetValues(typeof(TestEnum)).Cast<TestEnum>()
                        .SequenceEqual(f.Field<IEnumerable<TestEnum>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyEnumElement)).Returns(expected);

                TestEnum actual = sut.New();

                Assert.Equal(expected, actual);
            }
        }
    }
}
