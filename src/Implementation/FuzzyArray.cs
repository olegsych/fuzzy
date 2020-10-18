using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyArray<T> : Fuzzy<T[]>
    {
        readonly Func<T> itemFactory;
        readonly Length length;

        public FuzzyArray(IFuzz fuzzy, Func<T> itemFactory, Length length) : base(fuzzy) {
            this.itemFactory = itemFactory ?? throw new ArgumentNullException(nameof(itemFactory));
            this.length = length ?? throw new ArgumentNullException(nameof(length));
        }

        protected internal override T[] Build()
        {
            var result = new T[length.New(fuzzy)];
            for(int i = 0; i < result.Length; i++)
                result[i] = itemFactory();
            return result;
        }
    }
}
