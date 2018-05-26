using System;

namespace Fuzzy
{
    public class FuzzyArray<T> : Fuzzy<T[]>
    {
        public FuzzyArray(IFuzz fuzz) : base(fuzz)
        {
            throw new NotImplementedException();
        }

        public override T[] New()
        {
            throw new NotImplementedException();
        }
    }
}
