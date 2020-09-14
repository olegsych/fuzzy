using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyTimeSpan: Fuzzy<TimeSpan>
    {
        public FuzzyTimeSpan(IFuzz fuzzy) : base(fuzzy) { }
        public override TimeSpan New() => new TimeSpan(fuzzy.Int64());
    }
}
