using System;

namespace Fuzzy
{
    public static class TimeSpanExtensions
    {
        public static FuzzyRange<TimeSpan> Ticks(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(1);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerMillisecond - 1);
            return value;
        }

        public static FuzzyRange<TimeSpan> Milliseconds(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(TimeSpan.TicksPerMillisecond);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerSecond - 1);
            return value;
        }

        public static FuzzyRange<TimeSpan> Seconds(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(TimeSpan.TicksPerSecond);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerMinute - 1);
            return value;
        }

        public static FuzzyRange<TimeSpan> Minutes(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(TimeSpan.TicksPerMinute);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerHour - 1);
            return value;
        }

        public static FuzzyRange<TimeSpan> Hours(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(TimeSpan.TicksPerHour);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerDay - 1);
            return value;
        }

        public static FuzzyRange<TimeSpan> Days(this FuzzyRange<TimeSpan> value) {
            value.Minimum = new TimeSpan(TimeSpan.TicksPerDay);
            value.Maximum = new TimeSpan(TimeSpan.TicksPerDay * 7 - 1);
            return value;
        }
    }
}
