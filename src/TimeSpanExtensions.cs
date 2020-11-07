using System;

namespace Fuzzy
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Ticks(this TimeSpan value)
            => value.Between(new TimeSpan(1), new TimeSpan(TimeSpan.TicksPerMillisecond - 1));

        public static TimeSpan Milliseconds(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerMillisecond), new TimeSpan(TimeSpan.TicksPerSecond - 1));

        public static TimeSpan Seconds(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerSecond), new TimeSpan(TimeSpan.TicksPerMinute - 1));

        public static TimeSpan Minutes(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerMinute), new TimeSpan(TimeSpan.TicksPerHour - 1));

        public static TimeSpan Hours(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerHour), new TimeSpan(TimeSpan.TicksPerDay - 1));

        public static TimeSpan Days(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerDay), new TimeSpan(TimeSpan.TicksPerDay * 7 - 1));
    }
}
