namespace Fuzzy.Implementation
{
    sealed class FuzzyInt16: Fuzzy<short>
    {
        public FuzzyInt16(IFuzz fuzzy) : base(fuzzy) { }

        public override short New() {
            int sign = fuzzy.Next() % 2 == 0 ? 1 : -1;
            return (short)(sign * (fuzzy.Next() % (short.MaxValue + 1)));
        }
    }
}
