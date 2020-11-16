using System.Linq;
using Fuzzy.Implementation;

namespace Fuzzy
{
    public static class StringExtensions
    {
        public static string LettersOrDigits(this string value) {
            FuzzyString spec = FuzzyContext.Get<string, FuzzyString>(value);
            spec.Characters = spec.Characters.Where(c => char.IsLetterOrDigit(c)).ToArray();
            return spec;
        }
    }
}
