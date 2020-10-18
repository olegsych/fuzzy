using System;
using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class DictionaryExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateDictionaryOfFuzzyElements() {
            Dictionary<int, string> values = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateDictionaryOfFuzzyElementsWithCountSpecification() {
            Dictionary<int, string> values = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Between(41, 43));
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateDictionaryOfExistingElements() {
            IEnumerable<KeyValuePair<int, string>> existing = new Dictionary<int, string> {
                [41] = "foo", [42] = "bar", [43] = "baz"
            };
            Dictionary<int, string> selected = fuzzy.Dictionary(existing);
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateDictionaryOfExistingElementsWithCountSpecification() {
            IEnumerable<KeyValuePair<int, string>> existing = new Dictionary<int, string> {
                [41] = "foo", [42] = "bar", [43] = "baz"
            };
            Dictionary<int, string> selected = fuzzy.Dictionary(existing, Count.Between(2, 3));
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateDictionaryOfCustomElements() {
            int key = Environment.TickCount;
            Dictionary<int, string> values = fuzzy.Dictionary(() => key++, () => $"value{key}");
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void CreateArrayOfCustomElementsWithCountSpecification() {
            int key = Environment.TickCount;
            Dictionary<int, string> values = fuzzy.Dictionary(() => key++, () => $"value{key}", Count.Between(42, 43));
        }

        [Fact(Skip = Reason.NotImplemented)]
        public void ControlDictionaryCount() {
            DateTimeOffset[] dates;
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Exactly(42));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Between(41, 43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Max(43));
            dates = fuzzy.Array(fuzzy.DateTimeOffset, Length.Min(5));
        }
    }
}
