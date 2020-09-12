using System;

namespace Fuzzy
{
    public abstract class Fuzzy<T>
    {
        protected readonly IFuzz fuzzy;

        public Fuzzy(IFuzz fuzz) =>
            this.fuzzy = fuzz ?? throw new ArgumentNullException(nameof(fuzz));

        public abstract T New();

        public static implicit operator T(Fuzzy<T> fuzzy) =>
            fuzzy.New();
    }
}
