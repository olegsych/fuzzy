using System;
using System.Collections.Generic;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides <see cref="IFuzz"/> extension methods that produce fuzzy lists.
    /// </summary>
    public static class IFuzzListExtensions
    {
        /// <summary>Returns a fuzzy <see cref="System.Collections.Generic.List{T}"/> whose elements are produced by <paramref name="createElement"/> and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="createElement"/> is <see langword="null"/>.</exception>
        // TODO: When createElement is null, the ArgumentNullException thrown by FuzzyList<T> has ParamName == "itemFactory" instead of "createElement".
        public static List<T> List<T>(this IFuzz fuzzy, Func<T> createElement, Count? count = default) =>
            new FuzzyList<T>(fuzzy, createElement, count ?? new Count());

        /// <summary>Returns a fuzzy <see cref="System.Collections.Generic.List{T}"/> whose elements are chosen from <paramref name="elements"/> and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>, or <paramref name="elements"/> is <see langword="null"/> and the generated list count is non-zero.</exception>
        // TODO: When elements is null and the generated count is non-zero, the ArgumentNullException thrown by FuzzyElement<T> has ParamName == "candidates" instead of "elements".
        // TODO: When elements is empty and the generated count is non-zero, an internal ArgumentOutOfRangeException (ParamName == "value")
        // leaks from the FuzzyRange.Maximum setter via Between(0, -1), instead of a domain-appropriate exception about elements.
        public static List<T> List<T>(this IFuzz fuzzy, IEnumerable<T> elements, Count? count = default) =>
            fuzzy.List(() => fuzzy.Element(elements), count);
    }
}
