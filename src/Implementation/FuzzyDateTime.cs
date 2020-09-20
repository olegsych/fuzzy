using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyDateTime: FuzzyRange<DateTime>
    {
        public FuzzyDateTime(IFuzz fuzzy): base(fuzzy, DateTime.MinValue, DateTime.MaxValue) { }

        public override DateTime New() {
            long ticks = fuzzy.Int64().Between(Minimum.Ticks, Maximum.Ticks);
            var kind = fuzzy.Enum<DateTimeKind>();
            return new DateTime(ticks, kind);
        }
    }
}
