namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt64: Fuzzy<ulong>
    {
        public FuzzyUInt64(IFuzz fuzzy) : base(fuzzy) { }
        public override ulong New() => (ulong)fuzzy.UInt32() * fuzzy.UInt32();
    }
}
