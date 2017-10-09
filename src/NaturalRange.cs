using System;

namespace Fuzzy
{
    public abstract class NaturalRange<TRange> : Range<TRange> where TRange : NaturalRange<TRange>, new()
    {
        protected sealed override void Initialize(int? min, int? max)
        {
            if (min < 0)
                throw new ArgumentOutOfRangeException();
            base.Initialize(min, max);
        }
    }
}
