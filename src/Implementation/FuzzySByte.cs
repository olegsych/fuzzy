namespace Fuzzy.Implementation
{
    sealed class FuzzySByte: FuzzyRange<sbyte>
    {
        public FuzzySByte(IFuzz fuzzy) : base(fuzzy, sbyte.MinValue, sbyte.MaxValue) { }
        protected internal override sbyte Build() => (sbyte)fuzzy.Int16().Between(Minimum, Maximum);
    }
}
