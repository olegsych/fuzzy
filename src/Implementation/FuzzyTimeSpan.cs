using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyTimeSpan: FuzzyRange<TimeSpan>
    {
        public FuzzyTimeSpan(IFuzz fuzzy) : base(fuzzy, TimeSpan.MinValue, TimeSpan.MaxValue) { }
        protected internal override TimeSpan Build() => new TimeSpan(fuzzy.Int64().Between(Minimum.Ticks, Maximum.Ticks));
    }
}
