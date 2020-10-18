using System;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzySByteTest: FuzzyTestFixture
    {
        readonly FuzzyRange<sbyte> sut;

        public FuzzySByteTest() =>
            sut = new FuzzySByte(fuzzy);

        public class Constructor: FuzzySByteTest
        {
            [Fact]
            public void InitializesBaseClass() {
                Assert.Same(fuzzy, sut.Field<IFuzz>().Value);
                Assert.Equal(sbyte.MinValue, sut.Minimum);
                Assert.Equal(sbyte.MaxValue, sut.Maximum);
            }
        }

        public class Build: FuzzySByteTest
        {
            [Fact]
            public void ReturnsFuzzyInt16ValueConvertedToSByte() {
                sut.Minimum = (sbyte)(random.Next() % 64);
                sut.Maximum = (sbyte)(sut.Minimum + random.Next() % 64);
                var expected = (short)(random.Next() % sbyte.MaxValue);
                Expression<Predicate<FuzzyRange<short>>> fuzzyInt16 = v => v.Minimum == sut.Minimum && v.Maximum == sut.Maximum;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyInt16)).Returns(expected);

                sbyte actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
