namespace Fuzzy.Implementation
{
    sealed class FuzzyByte: Fuzzy<byte>
    {
        public FuzzyByte(IFuzz fuzzy) : base(fuzzy) {}
        public override byte New() => (byte)(fuzzy.Next() % (byte.MaxValue + 1));
    }
}
