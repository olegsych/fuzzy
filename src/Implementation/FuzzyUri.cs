using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyUri: Fuzzy<Uri>
    {
        public FuzzyUri(IFuzz fuzzy) : base(fuzzy) {}
        protected internal override Uri Build() => new Uri($"https://fuzzy{fuzzy.Number()}");
    }
}
