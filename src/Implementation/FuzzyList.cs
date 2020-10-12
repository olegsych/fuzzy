using System;
using System.Collections.Generic;

namespace Fuzzy.Implementation
{
    sealed class FuzzyList<T> : Fuzzy<List<T>>
    {
        readonly Func<T> itemFactory;
        readonly Count itemCount;

        public FuzzyList(IFuzz fuzzy, Func<T> itemFactory, Count itemCount) : base(fuzzy) {
            this.itemFactory = itemFactory ?? throw new ArgumentNullException(nameof(itemFactory));
            this.itemCount = itemCount ?? throw new ArgumentNullException(nameof(itemCount));
        }

        public override List<T> New()
        {
            var result = new List<T>(itemCount.New(fuzzy));
            for(int i = 0; i < result.Capacity; i++)
                result.Add(itemFactory());
            return result;
        }
    }
}
