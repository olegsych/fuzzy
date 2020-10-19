using System;
using System.Collections.Generic;

namespace Fuzzy.Implementation
{
    public sealed class FuzzyList<T> : FuzzyCollection<List<T>, T>
    {
        readonly Func<T> itemFactory;
        readonly Count itemCount;

        public FuzzyList(IFuzz fuzzy, Func<T> itemFactory, Count itemCount) : base(fuzzy) {
            this.itemFactory = itemFactory ?? throw new ArgumentNullException(nameof(itemFactory));
            this.itemCount = itemCount ?? throw new ArgumentNullException(nameof(itemCount));
        }

        protected internal override List<T> Build()
        {
            var result = new List<T>(itemCount.Build(fuzzy));
            for(int i = 0; i < result.Capacity; i++)
                result.Add(itemFactory());
            return result;
        }
    }
}
