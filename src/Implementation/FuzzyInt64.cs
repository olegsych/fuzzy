using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyInt64: Fuzzy<long>
    {
        public FuzzyInt64(IFuzz fuzzy) : base(fuzzy) { }

        public override long New() {
            throw new NotImplementedException();
        }
    }
}
