using System;
using System.Collections.Generic;
using Inspector;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class FuzzyRangeTest
    {
        readonly FuzzyRange<TestStruct> sut;

        // Constructor parameters
        readonly IFuzz fuzz = Substitute.For<IFuzz>();

        public FuzzyRangeTest() =>
            sut = Substitute.ForPartsOf<FuzzyRange<TestStruct>>(fuzz);

        public class Constructor: FuzzyRangeTest
        {
            [Fact]
            public void CallsBaseConstructor() =>
                Assert.Same(fuzz, sut.DeclaredBy<Fuzzy<TestStruct>>().Field<IFuzz>().Value);
        }

        public class Included: FuzzyRangeTest
        {
            [Fact]
            public void IsEmptyByDefault() {
                ISet<TestStruct> actual = sut.Included;
                Assert.Equal(0, actual.Count);
            }
        }

        public class Maximum: FuzzyRangeTest
        {
            [Fact]
            public void IsNullByDefault() {
                TestStruct? actual = sut.Maximum;
                Assert.False(actual.HasValue);
            }

            [Fact]
            public void CanBeSet() {
                var expected = new TestStruct(random.Next());
                sut.Maximum = expected;
                TestStruct? actual = sut.Maximum;
                Assert.Equal(expected, actual);
            }
        }

        public class Minimum: FuzzyRangeTest
        {
            [Fact]
            public void IsNullByDefault() {
                TestStruct? actual = sut.Minimum;
                Assert.False(actual.HasValue);
            }

            [Fact]
            public void CanBeSet() {
                var expected = new TestStruct(random.Next());
                sut.Minimum = expected;
                TestStruct? actual = sut.Minimum;
                Assert.Equal(expected, actual);
            }
        }

        public struct TestStruct: IComparable<TestStruct>, IEquatable<TestStruct>
        {
            readonly int value;
            public TestStruct(int value) => this.value = value;
            public int CompareTo(TestStruct other) => value.CompareTo(other.value);
            public bool Equals(TestStruct other) => value.Equals(other.value);
        }

        static readonly Random random = new Random();
    }
}
