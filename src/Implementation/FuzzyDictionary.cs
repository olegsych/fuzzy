using System;
using System.Collections.Generic;

namespace Fuzzy.Implementation
{
    sealed class FuzzyDictionary<TKey, TValue>: Fuzzy<Dictionary<TKey, TValue>>
    {
        readonly Func<TKey> keyFactory;
        readonly Func<TKey, TValue> valueFactory;
        readonly Count count;

        public FuzzyDictionary(IFuzz fuzzy, Func<TKey> keyFactory, Func<TKey, TValue> valueFactory, Count count): base(fuzzy) {
            this.keyFactory = keyFactory ?? throw new ArgumentNullException(nameof(keyFactory));
            this.valueFactory = valueFactory ?? throw new ArgumentNullException(nameof(valueFactory));
            this.count = count ?? throw new ArgumentNullException(nameof(count));
        }

        protected internal override Dictionary<TKey, TValue> Build() {
            int numberOfElements = count.Build(fuzzy);
            var dictionary = new Dictionary<TKey, TValue>(numberOfElements);
            for (int i = 0; i < numberOfElements; i++) {
                TKey key = keyFactory();
                dictionary[key] = valueFactory(key);
            }

            return dictionary;
        }
    }
}
