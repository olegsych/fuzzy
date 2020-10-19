using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyDateTime: FuzzyRange<DateTime>
    {
        readonly DateTimeKind? kind;

        public FuzzyDateTime(IFuzz fuzzy, DateTimeKind? kind = null) :
            base(fuzzy, DateTime.MinValue, DateTime.MaxValue) =>
            this.kind = kind;

        protected internal override DateTime Build() {
            long ticks = fuzzy.Int64().Between(Minimum.Ticks, Maximum.Ticks);
            DateTimeKind kind = this.kind ?? fuzzy.Enum<DateTimeKind>();
            return new DateTime(ticks, kind);
        }
    }
}
