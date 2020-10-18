namespace Fuzzy.Implementation
{
    sealed class FuzzyInt32: FuzzyRange<int>
    {
        public FuzzyInt32(IFuzz fuzzy) : base(fuzzy, int.MinValue, int.MaxValue) { }

        protected internal override int Build() {
            uint sample = fuzzy.UInt32();
            var range = (uint)(Maximum - Minimum);
            var increment = (uint)(sample % (range + 1L));
            return (int)(Minimum + increment);
        }
    }
}
