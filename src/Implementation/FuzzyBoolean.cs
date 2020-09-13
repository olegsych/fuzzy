namespace Fuzzy.Implementation
{
    sealed class FuzzyBoolean: Fuzzy<bool>
    {
        public FuzzyBoolean(IFuzz fuzzy) : base(fuzzy) {}
        public override bool New() => fuzzy.Next() % 2 == 1;
    }
}
