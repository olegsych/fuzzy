using System;

namespace Fuzzy.Implementation
{
    public abstract class Fuzzy<T>
    {
        protected readonly IFuzz fuzzy;

        protected Fuzzy(IFuzz fuzzy) =>
            this.fuzzy = fuzzy ?? throw new ArgumentNullException(nameof(fuzzy));

        protected internal abstract T Build();

        public T Generate() => fuzzy.Build(this);
    }
}
