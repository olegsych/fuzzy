namespace Fuzzy.Implementation
{
    sealed class FuzzyByte: Fuzzy<byte>
    {
        public FuzzyByte(IFuzz fuzz) : base(fuzz) {}
        public override byte New() => (byte)(fuzzy.Next() % byte.MaxValue);
    }
}
