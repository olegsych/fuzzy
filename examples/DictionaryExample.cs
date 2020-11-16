using System;
using System.Collections.Generic;
using Xunit;

namespace Fuzzy
{
    public class DictionaryExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void CreateDictionaryOfFuzzyElements() {
            Dictionary<int, string> values = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String);
        }

        [Fact]
        public void CreateDictionaryOfFuzzyElementsWithCountSpecification() {
            Dictionary<int, string> values = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Between(41, 43));
        }

        [Fact]
        public void CreateDictionaryOfExistingElements() {
            var existing = new Dictionary<int, string> {
                [41] = "foo", [42] = "bar", [43] = "baz"
            };
            Dictionary<int, string> selected = fuzzy.Dictionary(existing);
        }

        [Fact]
        public void CreateDictionaryOfExistingElementsWithCountSpecification() {
            var existing = new Dictionary<int, string> {
                [41] = "foo", [42] = "bar", [43] = "baz"
            };
            Dictionary<int, string> selected = fuzzy.Dictionary(existing, Count.Between(2, 3));
        }

        [Fact]
        public void CreateDictionaryOfCustomElements() {
            int key = Environment.TickCount;
            Dictionary<int, string> values = fuzzy.Dictionary(() => key++, k => $"value{k}");
        }

        [Fact]
        public void CreateArrayOfCustomElementsWithCountSpecification() {
            int key = Environment.TickCount;
            Dictionary<int, string> values = fuzzy.Dictionary(() => key++, k => $"value{k}", Count.Between(42, 43));
        }

        [Fact]
        public void ControlDictionaryCount() {
            Dictionary<int, string> dictionary;
            dictionary = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Exactly(42));
            dictionary = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Between(41, 43));
            dictionary = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Max(43));
            dictionary = fuzzy.Dictionary(fuzzy.Int32, fuzzy.String, Count.Min(5));
        }
    }
}
