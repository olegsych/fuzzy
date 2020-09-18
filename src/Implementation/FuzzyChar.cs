namespace Fuzzy.Implementation
{
    sealed class FuzzyChar: FuzzyRange<char>
    {
        public FuzzyChar(IFuzz fuzzy) : base(fuzzy, char.MinValue, char.MaxValue) {}
        public override char New() => (char)fuzzy.UInt16().Between(Minimum, Maximum);
    }
}
