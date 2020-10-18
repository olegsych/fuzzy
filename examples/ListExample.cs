using System;
using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class ListExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void CreateListOfFuzzyElements() {
            List<int> values = fuzzy.List(fuzzy.Int32);
        }

        [Fact]
        public void CreateListOfFuzzyElementsWithCountSpecification() {
            List<int> values = fuzzy.List(fuzzy.Int32, Count.Between(41, 43));
        }

        [Fact]
        public void CreateListOfExistingElements() {
            IEnumerable<int> existing = new[] { 41, 42, 43 };
            List<int> selected = fuzzy.List(existing);
        }

        [Fact]
        public void CreateListOfExistingElementsWithCountConstraints() {
            IEnumerable<int> existing = new[] { 41, 42, 43, 44, 45 };
            List<int> selected = fuzzy.List(existing, Count.Between(2, 4));

        }

        [Fact]
        public void CreateListOfCustomElements() {
            List<int> values = fuzzy.List(() => Environment.TickCount);
        }

        [Fact]
        public void CreateListOfCustomElementsWithCountConstraints() {
            List<int> values = fuzzy.List(() => Environment.TickCount, Count.Between(42, 43));
        }

        [Fact]
        public void ControlListCount() {
            List<int> values;
            values = fuzzy.List(fuzzy.Int32, Count.Between(41, 43));
            values = fuzzy.List(fuzzy.Int32, Count.Max(43));
            values = fuzzy.List(fuzzy.Int32, Count.Min(5));
        }
    }
}
