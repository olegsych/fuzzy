namespace Fuzzy.Implementation
{
    sealed class FuzzyChar: FuzzyRange<char>
    {
        public FuzzyChar(IFuzz fuzzy) : base(fuzzy, char.MinValue, char.MaxValue) {}
        protected internal override char Build() => (char)fuzzy.UInt16().Between(Minimum, Maximum);
    }
}
