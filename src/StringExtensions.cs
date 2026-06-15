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

        /// <summary>Returns a fuzzy <see langword="string"/> that excludes the specified characters.</summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a fuzzy value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="characters"/> is <see langword="null"/>.</exception>
        // TODO: When characters is null, the ArgumentNullException thrown by Enumerable.Contains has ParamName == "source" instead of "characters".
        public static string Except(this string value, params char[] characters) {
            FuzzyString spec = FuzzyContext.Get<string, FuzzyString>(value);
            spec.Characters = spec.Characters.Where(c => !characters.Contains(c)).ToArray();
            return spec;
        }
    }
}
