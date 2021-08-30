namespace Fuzzy.Implementation
{
    sealed class FuzzyBoolean: Fuzzy<bool>
    {
        public FuzzyBoolean(IFuzz fuzzy) : base(fuzzy) {}
        protected internal override bool Build() => fuzzy.Number() % 2 == 1;
    }
}
