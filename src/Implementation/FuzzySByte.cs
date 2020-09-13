namespace Fuzzy.Implementation
{
    sealed class FuzzySByte: Fuzzy<sbyte>
    {
        public FuzzySByte(IFuzz fuzzy) : base(fuzzy) { }

        public override sbyte New() {
            int sign = fuzzy.Next() % 2 == 0 ? 1 : -1;
            return (sbyte)(sign * (fuzzy.Next() % (sbyte.MaxValue + 1)));
        }
    }
}
