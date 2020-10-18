using System;

namespace Fuzzy
{
    public abstract class Fuzzy<T>
    {
        readonly Lazy<T> lazy;
        protected readonly IFuzz fuzzy;

        public Fuzzy(IFuzz fuzzy) {
            this.fuzzy = fuzzy ?? throw new ArgumentNullException(nameof(fuzzy));
            lazy = new Lazy<T>(() => fuzzy.Build(this)); // Call IFuzz.Build for testability
        }

        public T Value => lazy.Value;

        protected internal abstract T Build();

        public static implicit operator T(Fuzzy<T> fuzzy) => fuzzy.Value;
    }
}
