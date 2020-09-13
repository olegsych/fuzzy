namespace Fuzzy.Implementation
{
    sealed class FuzzyString: Fuzzy<string>
    {
        public FuzzyString(IFuzz fuzzy) : base(fuzzy) {}
        public override string New() => $"fuzzy{fuzzy.Next()}";
    }
}
