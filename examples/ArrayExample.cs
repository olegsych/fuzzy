using System;
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
        public void CreateArrayOfExistingElements() {
            int[] existing = { 41, 42, 43 };
            int[] selected = fuzzy.Array(existing);
        }

        [Fact]
        public void CreateArrayOfCustomElements() {
            int[] numbers = fuzzy.Array(() => Environment.TickCount);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ControlArrayLength() {
            DateTimeOffset[] dates;
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Exactly(42));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Between(41, 43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Max(43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Min(5));
        }
    }
}
