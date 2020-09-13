namespace Fuzzy.Implementation
{
    sealed class FuzzyChar: Fuzzy<char>
    {
        public FuzzyChar(IFuzz fuzzy) : base(fuzzy) {}
        public override char New() => (char)(fuzzy.Next() % (char.MaxValue + 1));
    }
}
