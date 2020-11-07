using System;

namespace Fuzzy
{
    public abstract class Fuzzy<T>
    {
        protected readonly IFuzz fuzzy;

        public Fuzzy(IFuzz fuzzy) =>
            this.fuzzy = fuzzy ?? throw new ArgumentNullException(nameof(fuzzy));

        protected internal abstract T Build();

        public static implicit operator T(Fuzzy<T> spec) => spec.fuzzy.Build(spec);
    }
}
