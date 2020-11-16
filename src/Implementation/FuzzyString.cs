using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuzzy.Implementation
{
    sealed class FuzzyString: Fuzzy<string>
    {
        static readonly IEnumerable<char> printableAsciiCharacters = PrintableAsciiCharacters();
        readonly Length length;
        IEnumerable<char> characters;

        public FuzzyString(IFuzz fuzzy, Length length = default, IEnumerable<char> characters = default) : base(fuzzy) {
            this.characters = characters ?? printableAsciiCharacters;
            this.length = length ?? new Length();
        }

        public IEnumerable<char> Characters {
            get => characters;
            set => characters = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected internal override string Build() => new string(fuzzy.Array(characters, length));

        static IEnumerable<char> PrintableAsciiCharacters() {
            const char first = '\x20', last = '\x7E';
            const int numberOfCharacters = last - first + 1;
            return Enumerable.Range(first, numberOfCharacters).Select(code => (char)code).ToArray();
        }
    }
}
