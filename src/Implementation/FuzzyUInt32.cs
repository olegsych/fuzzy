namespace Fuzzy.Implementation
{
    sealed class FuzzyUInt32: Fuzzy<uint>
    {
        public FuzzyUInt32(IFuzz fuzzy) : base(fuzzy) { }

        public override uint New() {
            uint mask = fuzzy.Next() % 2 == 0 ? 0 : 0x80000000;
            return mask | (uint)fuzzy.Next();
        }
    }
}
