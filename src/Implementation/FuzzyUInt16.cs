namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt16: Fuzzy<ushort>
    {
        public FuzzyUInt16(IFuzz fuzzy) : base(fuzzy) {}
        public override ushort New() => (ushort)(fuzzy.Next() % (ushort.MaxValue + 1));
    }
}
