using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyTimeSpan: FuzzyRange<TimeSpan>
    {
        public FuzzyTimeSpan(IFuzz fuzzy) : base(fuzzy, TimeSpan.MinValue, TimeSpan.MaxValue) { }
        public override TimeSpan New() => new TimeSpan(fuzzy.Int64().Between(Minimum.Ticks, Maximum.Ticks));
    }
}
