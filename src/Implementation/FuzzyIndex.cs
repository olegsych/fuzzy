using System.Collections.Generic;
using System.Linq;

namespace Fuzzy.Implementation
{
    sealed class FuzzyIndex<T>: Fuzzy<int>
    {
        readonly IEnumerable<T> elements;

        public FuzzyIndex(IFuzz fuzzy, IEnumerable<T> elements): base(fuzzy) =>
            this.elements = elements ?? throw new System.ArgumentNullException(nameof(elements));

        public override int New() =>
            fuzzy.Int32().Between(0, elements.Count() - 1);
    }
}
