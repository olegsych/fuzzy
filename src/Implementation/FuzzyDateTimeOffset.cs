using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyDateTimeOffset: FuzzyRange<DateTimeOffset>
    {
        public FuzzyDateTimeOffset(IFuzz fuzzy): base(fuzzy, DateTimeOffset.MinValue, DateTimeOffset.MaxValue) { }

        public override DateTimeOffset New() {
            const int maxOffsetMinutes = 14 * 60;
            var offset = TimeSpan.FromMinutes(fuzzy.Int32().Between(-maxOffsetMinutes, maxOffsetMinutes));

            long utcTicks = fuzzy.Int64().Between(Minimum.Ticks, Maximum.Ticks);
            if(utcTicks - offset.Ticks <= Minimum.UtcTicks)
                utcTicks = Minimum.UtcTicks + offset.Ticks;
            if(utcTicks - offset.Ticks >= Maximum.UtcTicks)
                utcTicks = Maximum.UtcTicks + offset.Ticks;

            return new DateTimeOffset(utcTicks, offset);
        }
    }
}
