namespace Fuzzy.Implementation
{
    sealed class FuzzyInt64: FuzzyRange<long>
    {
        public FuzzyInt64(IFuzz fuzzy) : base(fuzzy, long.MinValue, long.MaxValue) { }

        public override long New() {
            ulong sample = fuzzy.UInt64();
            var range = (ulong)(Maximum - Minimum);
            ulong increment = range == ulong.MaxValue ? sample : sample % (range + 1L);
            return Minimum + (long)increment;
        }
    }
}
