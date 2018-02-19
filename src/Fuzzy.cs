using System;

namespace Fuzzy
{
    public abstract class Fuzzy<T>
    {
        readonly IFuzz fuzz;

        public Fuzzy(IFuzz fuzz)
        {
            if (fuzz == null)
                throw new ArgumentNullException(nameof(fuzz));
        }

        public abstract T New();

        public static implicit operator T(Fuzzy<T> fuzzy)
        {
            return fuzzy.New();
        }
    }
}
