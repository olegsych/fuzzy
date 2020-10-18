using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyUri: Fuzzy<Uri>
    {
        public FuzzyUri(IFuzz fuzzy) : base(fuzzy) {}
        public override Uri New() => new Uri($"https://fuzzy{fuzzy.Next()}");
    }
}
