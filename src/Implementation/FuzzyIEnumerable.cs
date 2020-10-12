using System;
using System.Collections.Generic;

namespace Fuzzy.Implementation
{
    sealed class FuzzyIEnumerable<T> : Fuzzy<IEnumerable<T>>
    {
        readonly Func<T> itemFactory;
        readonly Count itemCount;

        public FuzzyIEnumerable(IFuzz fuzzy, Func<T> itemFactory, Count itemCount) : base(fuzzy) {
            this.itemFactory = itemFactory ?? throw new ArgumentNullException(nameof(itemFactory));
            this.itemCount = itemCount ?? throw new ArgumentNullException(nameof(itemCount));
        }

        public override IEnumerable<T> New()
        {
            for(int i = itemCount.New(fuzzy); i > 0; i--)
                yield return itemFactory();
        }
    }
}
