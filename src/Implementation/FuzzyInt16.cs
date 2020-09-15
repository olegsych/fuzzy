using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyInt16: FuzzyRange<short>
    {
        public FuzzyInt16(IFuzz fuzzy) : base(fuzzy, short.MinValue, short.MaxValue) { }

        public override short New() {
            int sample = Math.Abs(fuzzy.Next());
            var range = (ushort)(Maximum - Minimum);
            var increment = (ushort)(sample % (range + 1));
            return (short)(Minimum + increment);
        }
    }
}
