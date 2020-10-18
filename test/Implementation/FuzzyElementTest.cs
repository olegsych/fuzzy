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
    public class FuzzyElementTest: FuzzyTestFixture
    {
        readonly Fuzzy<TestStruct> sut;

        // Constructor parameters
        readonly IEnumerable<TestStruct> candidates;

        public FuzzyElementTest() {
            var items = new TestStruct[2 + random.Next() % 10];
            for(int i = 0; i < items.Length; i++)
                items[i] = new TestStruct(random.Next());
            candidates = items;
            sut = new FuzzyElement<TestStruct>(fuzzy, candidates);
        }

        public class Constructor: FuzzyElementTest
        {
            [Fact]
            public void InitializesBaseClass() =>
                Assert.Equal(fuzzy, sut.Field<IFuzz>().Value);

            [Fact]
            public void ThrowsDescriptiveExceptionWhenCandidatesIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => new FuzzyElement<TestStruct>(fuzzy, null));
                Assert.Equal("candidates", thrown.ParamName);
            }
        }

        public class Build: FuzzyElementTest
        {
            [Fact]
            public void ReturnsElementAtFuzzyIndex() {
                int expectedIndex = random.Next() % candidates.Count();
                Expression<Predicate<FuzzyIndex<TestStruct>>> fuzzyIndex = f => ReferenceEquals(candidates, f.Field<IEnumerable<TestStruct>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyIndex)).Returns(expectedIndex);

                TestStruct actual = sut.Build();

                Assert.Equal(candidates.ElementAt(expectedIndex), actual);
            }
        }
    }
}
