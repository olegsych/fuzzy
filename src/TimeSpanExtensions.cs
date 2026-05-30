using System;

namespace Fuzzy
{
    /// <summary>Provides range constraints for fuzzy <see cref="TimeSpan"/> values.</summary>
    public static class TimeSpanExtensions
    {
        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one tick and less than one millisecond.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Ticks(this TimeSpan value)
            => value.Between(new TimeSpan(1), new TimeSpan(TimeSpan.TicksPerMillisecond - 1));

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one millisecond and less than one second.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Milliseconds(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerMillisecond), new TimeSpan(TimeSpan.TicksPerSecond - 1));

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one second and less than one minute.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Seconds(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerSecond), new TimeSpan(TimeSpan.TicksPerMinute - 1));

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one minute and less than one hour.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Minutes(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerMinute), new TimeSpan(TimeSpan.TicksPerHour - 1));

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one hour and less than one day.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Hours(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerHour), new TimeSpan(TimeSpan.TicksPerDay - 1));

        /// <summary>Returns a fuzzy <see cref="TimeSpan"/> of at least one day and less than one week.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static TimeSpan Days(this TimeSpan value)
            => value.Between(new TimeSpan(TimeSpan.TicksPerDay), new TimeSpan(TimeSpan.TicksPerDay * 7 - 1));
    }
}
