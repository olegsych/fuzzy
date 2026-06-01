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
        public static List<T> List<T>(this IFuzz fuzzy, Func<T> createElement, Count? count = default) =>
            new FuzzyList<T>(fuzzy, createElement, count ?? new Count());

        /// <summary>Returns a fuzzy <see cref="System.Collections.Generic.List{T}"/> whose elements are chosen from <paramref name="elements"/> and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>, or <paramref name="elements"/> is <see langword="null"/> and the generated list count is non-zero.</exception>
        public static List<T> List<T>(this IFuzz fuzzy, IEnumerable<T> elements, Count? count = default) =>
            fuzzy.List(() => fuzzy.Element(elements), count);
    }
}
