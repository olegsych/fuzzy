using System;

namespace Fuzzy
{
    public abstract class Fuzzy<T>
    {
        protected readonly IFuzz fuzzy;

        public Fuzzy(IFuzz fuzzy) =>
            this.fuzzy = fuzzy ?? throw new ArgumentNullException(nameof(fuzzy));

        public abstract T New();

        public static implicit operator T(Fuzzy<T> fuzzy) => fuzzy.Build();

        // Call virtual IFuzz.Build<T>() for testability
        T Build() => fuzzy.Build(this);
    }
}
