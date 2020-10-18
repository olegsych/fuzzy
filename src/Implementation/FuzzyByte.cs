namespace Fuzzy.Implementation
{
    sealed class FuzzyByte: FuzzyRange<byte>
    {
        public FuzzyByte(IFuzz fuzzy) : base(fuzzy, byte.MinValue, byte.MaxValue) {}
        protected internal override byte Build() => (byte)fuzzy.UInt16().Between(Minimum, Maximum);
    }
}
