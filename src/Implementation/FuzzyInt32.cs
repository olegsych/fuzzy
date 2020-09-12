namespace Fuzzy.Implementation
{
    sealed class FuzzyInt32: Fuzzy<int>
    {
        public FuzzyInt32(IFuzz fuzzy) : base(fuzzy) { }

        public override int New() {
            int sign = fuzzy.Next() % 2 == 0 ? 1 : -1;
            return sign * fuzzy.Next();
        }
    }
}
