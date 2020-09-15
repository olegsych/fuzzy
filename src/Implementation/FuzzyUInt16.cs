using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt16: FuzzyRange<ushort>
    {
        public FuzzyUInt16(IFuzz fuzzy) : base(fuzzy, ushort.MinValue, ushort.MaxValue) { }

        public override ushort New() {
            int sample = Math.Abs(fuzzy.Next());
            var range = (ushort)(Maximum - Minimum);
            var increment = (ushort)(sample % (range + 1));
            return (ushort)(Minimum + increment);
        }
    }
}
