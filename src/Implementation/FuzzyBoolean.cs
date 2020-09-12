namespace Fuzzy.Implementation
{
    sealed class FuzzyBoolean: Fuzzy<bool>
    {
        public FuzzyBoolean(IFuzz fuzz) : base(fuzz) {}
        public override bool New() => fuzzy.Next() % 2 == 1;
    }
}
