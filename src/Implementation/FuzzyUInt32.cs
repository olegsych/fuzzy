namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt32: FuzzyRange<uint>
    {
        public FuzzyUInt32(IFuzz fuzzy) : base(fuzzy, uint.MinValue, uint.MaxValue) { }

        protected internal override uint Build() {
            ushort low = fuzzy.UInt16();
            ushort high = fuzzy.UInt16();
            long sample = high << 16 | low;
            uint range = Maximum - Minimum;
            var increment = (uint)(sample % (range + 1L));
            return Minimum + increment;
        }
    }
}
