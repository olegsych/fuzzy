namespace Fuzzy.Implementation
{
    sealed class FuzzyByte: FuzzyRange<byte>
    {
        public FuzzyByte(IFuzz fuzzy) : base(fuzzy, byte.MinValue, byte.MaxValue) {}
        public override byte New() => (byte)fuzzy.UInt16().Between(Minimum, Maximum);
    }
}
