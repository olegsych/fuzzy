using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class ArrayExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void CreateArrayOfNewElements() {
            int[] numbers = fuzzy.Array(fuzzy.Int32);
            DateTimeOffset[] dates = fuzzy.Array(fuzzy.DateTimeOffset);
            string[] strings = fuzzy.Array(fuzzy.String);
        }

        [Fact]
        public void ControlElementCreation() {
            DateTimeOffset[] dates = fuzzy.Array(() => fuzzy.DateTimeOffset().LessThan(DateTimeOffset.Now));
        }

        [Fact]
        public void ControlArrayLength() {
            DateTimeOffset[] dates;
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Exactly(42));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Between(41, 43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Max(43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Min(5));
        }

        [Fact]
        public void CreateArrayOfExistingElements() {
            DateTimeOffset[] existing = fuzzy.Array(fuzzy.DateTimeOffset);
            DateTimeOffset[] selected = fuzzy.Array(existing, Length.Between(41, 43));
        }
    }
}
