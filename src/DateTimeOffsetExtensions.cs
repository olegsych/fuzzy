using System;

namespace Fuzzy
{
    public static class DateTimeOffsetExtensions
    {
        public static FuzzyRange<DateTimeOffset> Between(this FuzzyRange<DateTimeOffset> value, DateTimeOffset minimum, TimeSpan timeSpan) {
            if(value is null)
                throw new ArgumentNullException(nameof(value));
            value.Minimum = minimum;
            value.Maximum = minimum + timeSpan;
            return value;
        }
    }
}
