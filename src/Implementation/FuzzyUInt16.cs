using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt16: FuzzyRange<ushort>
    {
        public FuzzyUInt16(IFuzz fuzzy) : base(fuzzy, ushort.MinValue, ushort.MaxValue) { }

        protected internal override ushort Build() {
            int sample = Math.Abs(fuzzy.Number());
            var range = (ushort)(Maximum - Minimum);
            var increment = (ushort)(sample % (range + 1));
            return (ushort)(Minimum + increment);
        }
    }
}
