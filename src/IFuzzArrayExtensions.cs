using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides <see cref="IFuzz"/> extension methods that produce fuzzy arrays.
    /// </summary>
    public static class IFuzzArrayExtensions
    {
        /// <summary>Returns a fuzzy array whose elements are produced by <paramref name="createElement"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="createElement"/> is <see langword="null"/>.</exception>
        // TODO: When createElement is null, the ArgumentNullException thrown by FuzzyArray<T> has ParamName == "itemFactory" instead of "createElement".
        public static T[] Array<T>(this IFuzz fuzzy, Func<T> createElement, Length? length = default) =>
            new FuzzyArray<T>(fuzzy, createElement, length ?? new Length());

        /// <summary>Returns a fuzzy array whose elements are chosen from <paramref name="elements"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>, or <paramref name="elements"/> is <see langword="null"/> and the generated array length is non-zero.</exception>
        public static T[] Array<T>(this IFuzz fuzzy, IEnumerable<T> elements, Length? length = default) =>
            fuzzy.Array(() => fuzzy.Element(elements), length);
    }
}
