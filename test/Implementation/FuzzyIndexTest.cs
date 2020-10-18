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
    public class FuzzyIndexTest: FuzzyTestFixture
    {
        readonly Fuzzy<int> sut;

        // Constructor parameters
        readonly IEnumerable<TestStruct> elements;

        public FuzzyIndexTest() {
            var items = new TestStruct[2 + random.Next() % 10];
            for(int i = 0; i < items.Length; i++)
                items[i] = new TestStruct(random.Next());
            elements = items;
            sut = new FuzzyIndex<TestStruct>(fuzzy, elements);
        }

        public class Constructor: FuzzyIndexTest
        {
            [Fact]
            public void InitializesBaseClass() =>
                Assert.Equal(fuzzy, sut.Field<IFuzz>().Value);

            [Fact]
            public void ThrowsDescriptiveExceptionWhenElementsIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyIndex<TestStruct>(fuzzy, null));
                Assert.Equal(sut.Constructor().Parameter<IEnumerable<TestStruct>>().Name, thrown.ParamName);
            }
        }

        public class Build: FuzzyIndexTest
        {
            [Fact]
            public void ReturnsIndexWithinBoundsOfCollection() {
                int expected = random.Next() % elements.Count();
                Expression<Predicate<FuzzyRange<int>>> fuzzyInt = v => v.Minimum == 0 && v.Maximum == elements.Count() - 1;
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyInt)).Returns(expected);

                int actual = sut.Build();

                Assert.Equal(expected, actual);
            }
        }
    }
}
