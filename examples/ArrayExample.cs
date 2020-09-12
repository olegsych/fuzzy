using System;
using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class ArrayExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void CreateArrayOfFuzzyElements() {
            int[] numbers = fuzzy.Array(fuzzy.Int32);
        }

        [Fact]
        public void CreateArrayOfFuzzyElementsWithLengthSpecification() {
            int[] numbers = fuzzy.Array(fuzzy.Int32, Length.Between(41, 43));
        }

        [Fact]
        public void CreateArrayOfExistingElements() {
            IEnumerable<int> existing = new[] { 41, 42, 43 };
            int[] selected = fuzzy.Array(existing);
        }

        [Fact]
        public void CreateArrayOfExistingElementsWithLengthConstraints() {
            IEnumerable<int> existing = new[] { 41, 42, 43, 44, 45 };
            int[] selected = fuzzy.Array(existing, Length.Between(2, 4));

        }

        [Fact]
        public void CreateArrayOfCustomElements() {
            int[] numbers = fuzzy.Array(() => Environment.TickCount);
        }

        [Fact]
        public void CreateArrayOfCustomElementsWithLengthConstraints() {
            int[] numbers = fuzzy.Array(() => Environment.TickCount, Length.Between(42, 43));
        }

        [Fact]
        public void ControlArrayLength() {
            DateTimeOffset[] dates;
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Exactly(42));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Between(41, 43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Max(43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Min(5));
        }
    }
}
