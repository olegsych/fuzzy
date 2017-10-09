using System;

namespace Fuzzy
{
    public class NaturalRange : Range<NaturalRange>
    {
        protected override void Initialize(int? min, int? max)
        {
            if (min < 0)
                throw new ArgumentOutOfRangeException();
            base.Initialize(min, max);
        }
    }
}
