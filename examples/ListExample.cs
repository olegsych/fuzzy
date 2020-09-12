using System;
using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class ListExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void CreateListOfFuzzyElements() {
            List<int> values = fuzzy.List(fuzzy.Int32);
        }

        [Fact]
        public void CreateListOfFuzzyElementsWithLengthSpecification() {
            List<int> values = fuzzy.List(fuzzy.Int32, Length.Between(41, 43));
        }

        [Fact]
        public void CreateListOfExistingElements() {
            IEnumerable<int> existing = new[] { 41, 42, 43 };
            List<int> selected = fuzzy.List(existing);
        }

        [Fact]
        public void CreateListOfExistingElementsWithLengthConstraints() {
            IEnumerable<int> existing = new[] { 41, 42, 43, 44, 45 };
            List<int> selected = fuzzy.List(existing, Length.Between(2, 4));

        }

        [Fact]
        public void CreateListOfCustomElements() {
            List<int> values = fuzzy.List(() => Environment.TickCount);
        }

        [Fact]
        public void CreateListOfCustomElementsWithLengthConstraints() {
            List<int> values = fuzzy.List(() => Environment.TickCount, Length.Between(42, 43));
        }

        [Fact]
        public void ControlListLength() {
            List<int> values;
            values = fuzzy.List(fuzzy.Int32, Length.Exactly(42));
            values = fuzzy.List(fuzzy.Int32, Length.Between(41, 43));
            values = fuzzy.List(fuzzy.Int32, Length.Max(43));
            values = fuzzy.List(fuzzy.Int32, Length.Min(5));
        }
    }
}
