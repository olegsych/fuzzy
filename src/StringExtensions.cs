using System;
using System.Linq;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>Provides character-set constraints for fuzzy <see langword="string"/> values.</summary>
    public static class StringExtensions
    {
        /// <summary>Returns a fuzzy <see langword="string"/> constrained to letters and digits.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        public static string LettersOrDigits(this string value) {
            FuzzyString spec = FuzzyContext.Get<string, FuzzyString>(value);
            spec.Characters = spec.Characters.Where(c => char.IsLetterOrDigit(c)).ToArray();
            return spec;
        }
    }
}
