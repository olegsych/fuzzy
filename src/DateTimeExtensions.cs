using System;

namespace Fuzzy
{
    public static class DateTimeExtensions
    {
        public static FuzzyRange<DateTime> Between(this FuzzyRange<DateTime> value, DateTime minimum, TimeSpan timeSpan) {
            if(value is null)
                throw new ArgumentNullException(nameof(value));
            value.Minimum = minimum;
            value.Maximum = minimum + timeSpan;
            return value;
        }
    }
}
