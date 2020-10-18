using System.Collections.Generic;
using System.Linq;

namespace Fuzzy.Implementation
{
    sealed class FuzzyElement<T>: Fuzzy<T>
    {
        readonly IEnumerable<T> candidates;

        public FuzzyElement(IFuzz fuzzy, IEnumerable<T> candidates): base(fuzzy) =>
            this.candidates = candidates ?? throw new System.ArgumentNullException(nameof(candidates));

        public override T New() =>
            candidates.ElementAt(fuzzy.Index(candidates));
    }
}
