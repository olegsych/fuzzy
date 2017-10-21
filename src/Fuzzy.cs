using System;

namespace Fuzzy
{
    public class Fuzzy<T>
    {
        readonly IFuzz fuzz;
        readonly Func<IFuzz, T> factory;

        public Fuzzy(IFuzz fuzz, Func<IFuzz, T> factory)
        {
            this.fuzz = fuzz ?? throw new ArgumentNullException(nameof(fuzz));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}
