namespace Fuzzy.Implementation
{
    sealed class FuzzyString: Fuzzy<string>
    {
        public FuzzyString(IFuzz fuzzy) : base(fuzzy) {}
        protected internal override string Build() => $"fuzzy{fuzzy.Next()}";
    }
}
