namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt64: FuzzyRange<ulong>
    {
        public FuzzyUInt64(IFuzz fuzzy) : base(fuzzy, ulong.MinValue, ulong.MaxValue) { }

        public override ulong New() {
            uint low = fuzzy.UInt32();
            uint high = fuzzy.UInt32();
            ulong sample = (ulong)high << 32 | low;
            ulong range = Maximum - Minimum;
            if(range == ulong.MaxValue)
                return sample;
            ulong increment = sample % (range + 1L);
            return Minimum + increment;
        }
    }
}
